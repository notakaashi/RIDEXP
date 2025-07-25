Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports MySql.Data.MySqlClient

Public Module Module3

    ' Generate invoice from rental ID
    Public Sub GenerateRideExpressInvoice(rentalId As Integer)
        Try
            Dim invoiceData = GetRentalDataFromDatabase(rentalId)
            If invoiceData IsNot Nothing Then
                CreatePDFInvoice(invoiceData, rentalId)
            Else
                MessageBox.Show("Could not retrieve rental data for invoice.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating invoice: " & ex.Message)
        End Try
    End Sub

    ' Generate invoice from current transaction data
    Public Sub GenerateInvoiceFromCurrentTransaction(rentalId As Integer)
        Try
            ' Generate immediately using current transaction data (no database needed)
            CreatePDFFromTransactionData(rentalId)
        Catch ex As Exception
            MessageBox.Show("Error generating invoice from transaction data: " & ex.Message)
        End Try
    End Sub

    ' Get rental data from database with separate connection
    Private Function GetRentalDataFromDatabase(rentalId As Integer) As Object
        Try
            ' Use a fresh connection to avoid transaction issues
            Using conn As New MySqlConnection("server=localhost;userid=root;password=;database=ridexp;Convert Zero Datetime=True;Allow Zero Datetime=True;")
                conn.Open()

                Dim query As String = "
                  SELECT 
    r.rental_id, 
    DATE_FORMAT(r.pickup_date, '%Y-%m-%d') as pickup_date_str, 
    TIME_FORMAT(r.pickup_time, '%H:%i:%s') as pickup_time_str, 
    DATE_FORMAT(r.return_date, '%Y-%m-%d') as return_date_str, 
    TIME_FORMAT(r.return_time, '%H:%i:%s') as return_time_str,
    r.pickup_place, 
    r.return_place, 
    r.amount, 
    r.rental_duration_days,
    c.first_name, 
    c.last_name,
    DATE_FORMAT(c.date_of_birth, '%Y-%m-%d') as date_of_birth_str,
    c.license_number,
    DATE_FORMAT(c.license_expiry, '%Y-%m-%d') as license_expiry_str,
    c.customer_id,
    c.customer_id,
    u.user_id,
    c.created_at,
    c.phone AS customer_phone,
    c.email AS customer_email,
    c.address AS customer_address,
    v.vehicle_type,
    CASE 
        WHEN v.vehicle_type = 'car' THEN CONCAT(cars.make, ' ', cars.model_name)
        WHEN v.vehicle_type = 'motor' THEN CONCAT(motors.make, ' ', motors.model)
        ELSE 'Unknown Vehicle'
    END AS vehicle_name,
    rr.rate_per_day AS daily_rate
FROM rentals r
INNER JOIN customers c ON r.customer_id = c.customer_id
LEFT JOIN user u ON c.user_id = u.user_id
INNER JOIN vehicles v ON r.vehicle_id = v.vehicle_id
LEFT JOIN cars ON (v.vehicle_type = 'car' AND v.item_id = cars.car_id)
LEFT JOIN motors ON (v.vehicle_type = 'motor' AND v.item_id = motors.motor_id)
LEFT JOIN rental_rate rr ON v.vehicle_id = rr.vehicle_id 
    AND rr.effective_date = (
        SELECT MAX(rr2.effective_date) 
        FROM rental_rate rr2 
        WHERE rr2.vehicle_id = v.vehicle_id 
        AND rr2.effective_date <= r.pickup_date
    )
WHERE r.rental_id = @rental_id
"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@rental_id", rentalId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Combine first_name and last_name to create full customer name
                            Dim firstName As String = If(IsDBNull(reader("first_name")), "", reader("first_name").ToString())
                            Dim lastName As String = If(IsDBNull(reader("last_name")), "", reader("last_name").ToString())
                            Dim fullName As String = $"{firstName} {lastName}".Trim()
                            If String.IsNullOrEmpty(fullName) Then fullName = "N/A"

                            Return New With {
                                .RentalId = reader("rental_id"),
                                .CustomerId = If(IsDBNull(reader("customer_id")), 0, reader("customer_id")),
                                .UserId = If(IsDBNull(reader("user_id")), 0, reader("user_id")),
                                .CustomerName = fullName,
                                .FirstName = If(IsDBNull(reader("first_name")), "N/A", reader("first_name").ToString()),
                                .LastName = If(IsDBNull(reader("last_name")), "N/A", reader("last_name").ToString()),
                                .DateOfBirth = If(IsDBNull(reader("date_of_birth_str")), "N/A", reader("date_of_birth_str").ToString()),
                                .CustomerEmail = If(IsDBNull(reader("customer_email")), "N/A", reader("customer_email").ToString()),
                                .CustomerPhone = If(IsDBNull(reader("customer_phone")), "N/A", reader("customer_phone").ToString()),
                                .CustomerAddress = If(IsDBNull(reader("customer_address")), "N/A", reader("customer_address").ToString()),
                                .LicenseNumber = If(IsDBNull(reader("license_number")), "N/A", reader("license_number").ToString()),
                                .LicenseExpiry = If(IsDBNull(reader("license_expiry_str")), "N/A", reader("license_expiry_str").ToString()),
                                .CustomerCreatedAt = If(IsDBNull(reader("created_at")), "N/A", reader("created_at").ToString()),
                                .VehicleName = If(IsDBNull(reader("vehicle_name")), "N/A", reader("vehicle_name").ToString()),
                                .VehicleType = If(IsDBNull(reader("vehicle_type")), "N/A", reader("vehicle_type").ToString()),
                                .PickupDate = If(IsDBNull(reader("pickup_date_str")), "N/A", reader("pickup_date_str").ToString()),
                                .PickupTime = If(IsDBNull(reader("pickup_time_str")), "N/A", reader("pickup_time_str").ToString()),
                                .ReturnDate = If(IsDBNull(reader("return_date_str")), "N/A", reader("return_date_str").ToString()),
                                .ReturnTime = If(IsDBNull(reader("return_time_str")), "N/A", reader("return_time_str").ToString()),
                                .PickupPlace = If(IsDBNull(reader("pickup_place")), "N/A", reader("pickup_place").ToString()),
                                .ReturnPlace = If(IsDBNull(reader("return_place")), "N/A", reader("return_place").ToString()),
                                .DailyRate = If(IsDBNull(reader("daily_rate")), 0D, reader("daily_rate")),
                                .RentalDays = If(IsDBNull(reader("rental_duration_days")), 1, reader("rental_duration_days")),
                                .TotalAmount = If(IsDBNull(reader("amount")), 0D, reader("amount"))
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message)
        End Try
        Return Nothing
    End Function

    ' Create PDF from database data
    Private Sub CreatePDFInvoice(data As Object, rentalId As Integer)
        Try
            Dim invoicePath As String = $"RideExpress_Invoice_{rentalId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"

            Using fs As New FileStream(invoicePath, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim doc As New Document(PageSize.A4, 40, 40, 40, 40)
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
                doc.Open()

                ' Define fonts
                Dim titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.DARK_GRAY)
                Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK)
                Dim labelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.DARK_GRAY)
                Dim infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK)
                Dim totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK)

                ' Company Header
                Dim companyTable As New PdfPTable(2)
                companyTable.WidthPercentage = 100
                companyTable.SetWidths({3, 1})
                companyTable.DefaultCell.Border = Rectangle.NO_BORDER

                ' Left side - Company info
                Dim companyCell As New PdfPCell()
                companyCell.Border = Rectangle.NO_BORDER
                companyCell.AddElement(New Paragraph("RIDEXPRESS", titleFont))
                companyCell.AddElement(New Paragraph("456 Transportation Avenue, Makati City", infoFont))
                companyCell.AddElement(New Paragraph("Metro Manila, Philippines 1234", infoFont))
                companyCell.AddElement(New Paragraph("Phone: +63 2 987-6543", infoFont))
                companyCell.AddElement(New Paragraph("Email: rentals@ridexpress.com", infoFont))
                companyTable.AddCell(companyCell)

                ' Right side - Invoice details
                Dim invoiceCell As New PdfPCell()
                invoiceCell.Border = Rectangle.NO_BORDER
                invoiceCell.HorizontalAlignment = Element.ALIGN_RIGHT
                invoiceCell.AddElement(New Paragraph("RENTAL INVOICE", headerFont))
                invoiceCell.AddElement(New Paragraph(" ", infoFont))
                invoiceCell.AddElement(New Paragraph($"Invoice #: RE-{DateTime.Now.Year}-{rentalId:D6}", infoFont))
                invoiceCell.AddElement(New Paragraph($"Date: {DateTime.Now:MMM dd, yyyy}", infoFont))
                invoiceCell.AddElement(New Paragraph($"Time: {DateTime.Now:HH:mm}", infoFont))
                companyTable.AddCell(invoiceCell)

                doc.Add(companyTable)
                doc.Add(New Paragraph(" "))

                ' Horizontal line
                Dim line As New LineSeparator(1.0F, 100.0F, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1)
                doc.Add(New Chunk(line))
                doc.Add(New Paragraph(" "))

                ' Customer Information
                doc.Add(New Paragraph("CUSTOMER INFORMATION", headerFont))
                doc.Add(New Paragraph(" "))

                Dim customerTable As New PdfPTable(2)
                customerTable.WidthPercentage = 100
                customerTable.SetWidths({1, 1})
                customerTable.DefaultCell.Border = Rectangle.NO_BORDER
                customerTable.DefaultCell.PaddingBottom = 5

                customerTable.AddCell(New Phrase("Customer Name:", labelFont))
                customerTable.AddCell(New Phrase(data.CustomerName, infoFont))
                customerTable.AddCell(New Phrase("Contact Number:", labelFont))
                customerTable.AddCell(New Phrase(data.CustomerPhone, infoFont))
                customerTable.AddCell(New Phrase("Email:", labelFont))
                customerTable.AddCell(New Phrase(data.CustomerEmail, infoFont))
                customerTable.AddCell(New Phrase("Address:", labelFont))
                customerTable.AddCell(New Phrase(data.CustomerAddress, infoFont))

                doc.Add(customerTable)
                doc.Add(New Paragraph(" "))

                ' Rental Details
                doc.Add(New Paragraph("RENTAL DETAILS", headerFont))
                doc.Add(New Paragraph(" "))

                ' Create detailed table
                Dim detailTable As New PdfPTable(4)
                detailTable.WidthPercentage = 100
                detailTable.SetWidths({3, 1, 1, 1})

                ' Table headers
                Dim headerCell1 As New PdfPCell(New Phrase("Description", labelFont))
                headerCell1.BackgroundColor = BaseColor.LIGHT_GRAY
                headerCell1.HorizontalAlignment = Element.ALIGN_CENTER
                headerCell1.Padding = 8
                detailTable.AddCell(headerCell1)

                Dim headerCell2 As New PdfPCell(New Phrase("Days", labelFont))
                headerCell2.BackgroundColor = BaseColor.LIGHT_GRAY
                headerCell2.HorizontalAlignment = Element.ALIGN_CENTER
                headerCell2.Padding = 8
                detailTable.AddCell(headerCell2)

                Dim headerCell3 As New PdfPCell(New Phrase("Rate/Day", labelFont))
                headerCell3.BackgroundColor = BaseColor.LIGHT_GRAY
                headerCell3.HorizontalAlignment = Element.ALIGN_CENTER
                headerCell3.Padding = 8
                detailTable.AddCell(headerCell3)

                Dim headerCell4 As New PdfPCell(New Phrase("Amount", labelFont))
                headerCell4.BackgroundColor = BaseColor.LIGHT_GRAY
                headerCell4.HorizontalAlignment = Element.ALIGN_CENTER
                headerCell4.Padding = 8
                detailTable.AddCell(headerCell4)

                ' Table data
                Dim description As String = $"{data.VehicleName} ({data.VehicleType})" & Chr(10) &
                                          $"Pickup: {data.PickupDate:MMM dd, yyyy} {data.PickupTime}" & Chr(10) &
                                          $"Return: {data.ReturnDate:MMM dd, yyyy} {data.ReturnTime}" & Chr(10) &
                                          $"From: {data.PickupPlace}" & Chr(10) &
                                          $"To: {data.ReturnPlace}"

                Dim dataCell1 As New PdfPCell(New Phrase(description, infoFont))
                dataCell1.Padding = 8
                dataCell1.VerticalAlignment = Element.ALIGN_MIDDLE
                detailTable.AddCell(dataCell1)

                Dim dataCell2 As New PdfPCell(New Phrase(data.RentalDays.ToString(), infoFont))
                dataCell2.HorizontalAlignment = Element.ALIGN_CENTER
                dataCell2.Padding = 8
                detailTable.AddCell(dataCell2)

                Dim dataCell3 As New PdfPCell(New Phrase($"₱{data.DailyRate:N2}", infoFont))
                dataCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                dataCell3.Padding = 8
                detailTable.AddCell(dataCell3)

                Dim subtotal As Decimal = data.DailyRate * data.RentalDays
                Dim dataCell4 As New PdfPCell(New Phrase($"₱{subtotal:N2}", infoFont))
                dataCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                dataCell4.Padding = 8
                detailTable.AddCell(dataCell4)

                doc.Add(detailTable)
                doc.Add(New Paragraph(" "))

                ' Summary section
                Dim summaryTable As New PdfPTable(2)
                summaryTable.WidthPercentage = 100
                summaryTable.SetWidths({3, 1})
                summaryTable.DefaultCell.Border = Rectangle.NO_BORDER

                ' Left side empty
                summaryTable.AddCell("")

                ' Right side - totals
                Dim totalsTable As New PdfPTable(2)
                totalsTable.WidthPercentage = 100
                totalsTable.DefaultCell.Border = Rectangle.NO_BORDER
                totalsTable.DefaultCell.PaddingBottom = 3

                Dim vatAmount As Decimal = subtotal * 0.12D
                Dim serviceAmount As Decimal = 100D

                totalsTable.AddCell(New Phrase("Subtotal:", labelFont))
                Dim subtotalCell As New PdfPCell(New Phrase($"₱{subtotal:N2}", infoFont))
                subtotalCell.Border = Rectangle.NO_BORDER
                subtotalCell.HorizontalAlignment = Element.ALIGN_RIGHT
                totalsTable.AddCell(subtotalCell)

                totalsTable.AddCell(New Phrase("VAT (12%):", labelFont))
                Dim vatCell As New PdfPCell(New Phrase($"₱{vatAmount:N2}", infoFont))
                vatCell.Border = Rectangle.NO_BORDER
                vatCell.HorizontalAlignment = Element.ALIGN_RIGHT
                totalsTable.AddCell(vatCell)

                totalsTable.AddCell(New Phrase("Service Fee:", labelFont))
                Dim serviceCell As New PdfPCell(New Phrase($"₱{serviceAmount:N2}", infoFont))
                serviceCell.Border = Rectangle.NO_BORDER
                serviceCell.HorizontalAlignment = Element.ALIGN_RIGHT
                totalsTable.AddCell(serviceCell)

                ' Total line
                Dim totalCell1 As New PdfPCell(New Phrase("TOTAL AMOUNT:", totalFont))
                totalCell1.Border = Rectangle.TOP_BORDER
                totalCell1.BorderWidth = 1
                totalCell1.PaddingTop = 8
                totalsTable.AddCell(totalCell1)

                Dim finalTotal As Decimal = data.TotalAmount
                Dim totalCell2 As New PdfPCell(New Phrase($"₱{finalTotal:N2}", totalFont))
                totalCell2.Border = Rectangle.TOP_BORDER
                totalCell2.BorderWidth = 1
                totalCell2.HorizontalAlignment = Element.ALIGN_RIGHT
                totalCell2.PaddingTop = 8
                totalsTable.AddCell(totalCell2)

                Dim summaryCell As New PdfPCell(totalsTable)
                summaryCell.Border = Rectangle.NO_BORDER
                summaryTable.AddCell(summaryCell)

                doc.Add(summaryTable)
                doc.Add(New Paragraph(" "))
                doc.Add(New Paragraph(" "))

                ' Payment info
                doc.Add(New Paragraph("PAYMENT INFORMATION", headerFont))
                doc.Add(New Paragraph(" "))

                Dim paymentTable As New PdfPTable(2)
                paymentTable.WidthPercentage = 100
                paymentTable.SetWidths({1, 1})
                paymentTable.DefaultCell.Border = Rectangle.NO_BORDER
                paymentTable.DefaultCell.PaddingBottom = 5

                paymentTable.AddCell(New Phrase("Payment Method:", labelFont))
                paymentTable.AddCell(New Phrase("Online Payment", infoFont))
                paymentTable.AddCell(New Phrase("Payment Status:", labelFont))
                paymentTable.AddCell(New Phrase("Paid", infoFont))
                paymentTable.AddCell(New Phrase("Transaction ID:", labelFont))
                paymentTable.AddCell(New Phrase($"TXN-{DateTime.Now:yyyyMMdd}-{rentalId}", infoFont))

                doc.Add(paymentTable)
                doc.Add(New Paragraph(" "))
                doc.Add(New Paragraph(" "))

                ' Footer
                doc.Add(New Chunk(line))
                doc.Add(New Paragraph(" "))

                Dim footerPara As New Paragraph("Thank you for choosing RideExpress!", infoFont)
                footerPara.Alignment = Element.ALIGN_CENTER
                doc.Add(footerPara)

                Dim footerNote As New Paragraph("For inquiries, please contact us at rentals@ridexpress.com or call +63 2 987-6543", infoFont)
                footerNote.Alignment = Element.ALIGN_CENTER
                doc.Add(footerNote)

                doc.Close()
                writer.Close()
            End Using

            MessageBox.Show($"RideExpress Invoice Created: {Path.GetFullPath(invoicePath)}")

        Catch ex As Exception
            MessageBox.Show("Error creating PDF: " & ex.Message)
        End Try
    End Sub

    ' Create PDF from current transaction data
    Private Sub CreatePDFFromTransactionData(rentalId As Integer)
        Try
            Dim invoicePath As String = $"RideExpress_Invoice_{rentalId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"

            Using fs As New FileStream(invoicePath, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim doc As New Document(PageSize.A4, 40, 40, 40, 40)
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
                doc.Open()

                ' Define fonts
                Dim titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.DARK_GRAY)
                Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK)
                Dim labelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.DARK_GRAY)
                Dim infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK)
                Dim totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK)

                ' Use transaction data
                With RentalTransactionModule.TransactionData
                    ' Company Header
                    Dim companyTable As New PdfPTable(2)
                    companyTable.WidthPercentage = 100
                    companyTable.SetWidths({3, 1})
                    companyTable.DefaultCell.Border = Rectangle.NO_BORDER

                    ' Left side - Company info
                    Dim companyCell As New PdfPCell()
                    companyCell.Border = Rectangle.NO_BORDER
                    companyCell.AddElement(New Paragraph("RIDEXPRESS", titleFont))
                    companyCell.AddElement(New Paragraph("456 Transportation Avenue, Makati City", infoFont))
                    companyCell.AddElement(New Paragraph("Metro Manila, Philippines 1234", infoFont))
                    companyCell.AddElement(New Paragraph("Phone: +63 2 987-6543", infoFont))
                    companyCell.AddElement(New Paragraph("Email: rentals@ridexpress.com", infoFont))
                    companyTable.AddCell(companyCell)

                    ' Right side - Invoice details
                    Dim invoiceCell As New PdfPCell()
                    invoiceCell.Border = Rectangle.NO_BORDER
                    invoiceCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    invoiceCell.AddElement(New Paragraph("RENTAL INVOICE", headerFont))
                    invoiceCell.AddElement(New Paragraph(" ", infoFont))
                    invoiceCell.AddElement(New Paragraph($"Invoice #: RE-{DateTime.Now.Year}-{rentalId:D6}", infoFont))
                    invoiceCell.AddElement(New Paragraph($"Date: {DateTime.Now:MMM dd, yyyy}", infoFont))
                    invoiceCell.AddElement(New Paragraph($"Time: {DateTime.Now:HH:mm}", infoFont))
                    companyTable.AddCell(invoiceCell)

                    doc.Add(companyTable)
                    doc.Add(New Paragraph(" "))

                    ' Horizontal line
                    Dim line As New LineSeparator(1.0F, 100.0F, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1)
                    doc.Add(New Chunk(line))
                    doc.Add(New Paragraph(" "))

                    ' Customer Information
                    doc.Add(New Paragraph("CUSTOMER INFORMATION", headerFont))
                    doc.Add(New Paragraph(" "))

                    Dim customerTable As New PdfPTable(2)
                    customerTable.WidthPercentage = 100
                    customerTable.SetWidths({1, 1})
                    customerTable.DefaultCell.Border = Rectangle.NO_BORDER
                    customerTable.DefaultCell.PaddingBottom = 5

                    customerTable.AddCell(New Phrase("Customer ID:", labelFont))
                    customerTable.AddCell(New Phrase(.CustomerId.ToString(), infoFont))
                    customerTable.AddCell(New Phrase("Rental ID:", labelFont))
                    customerTable.AddCell(New Phrase(rentalId.ToString(), infoFont))

                    doc.Add(customerTable)
                    doc.Add(New Paragraph(" "))

                    ' Rental Details
                    doc.Add(New Paragraph("RENTAL DETAILS", headerFont))
                    doc.Add(New Paragraph(" "))

                    ' Create detailed table
                    Dim detailTable As New PdfPTable(4)
                    detailTable.WidthPercentage = 100
                    detailTable.SetWidths({3, 1, 1, 1})

                    ' Table headers
                    Dim headerCell1 As New PdfPCell(New Phrase("Description", labelFont))
                    headerCell1.BackgroundColor = BaseColor.LIGHT_GRAY
                    headerCell1.HorizontalAlignment = Element.ALIGN_CENTER
                    headerCell1.Padding = 8
                    detailTable.AddCell(headerCell1)

                    Dim headerCell2 As New PdfPCell(New Phrase("Days", labelFont))
                    headerCell2.BackgroundColor = BaseColor.LIGHT_GRAY
                    headerCell2.HorizontalAlignment = Element.ALIGN_CENTER
                    headerCell2.Padding = 8
                    detailTable.AddCell(headerCell2)

                    Dim headerCell3 As New PdfPCell(New Phrase("Rate/Day", labelFont))
                    headerCell3.BackgroundColor = BaseColor.LIGHT_GRAY
                    headerCell3.HorizontalAlignment = Element.ALIGN_CENTER
                    headerCell3.Padding = 8
                    detailTable.AddCell(headerCell3)

                    Dim headerCell4 As New PdfPCell(New Phrase("Amount", labelFont))
                    headerCell4.BackgroundColor = BaseColor.LIGHT_GRAY
                    headerCell4.HorizontalAlignment = Element.ALIGN_CENTER
                    headerCell4.Padding = 8
                    detailTable.AddCell(headerCell4)

                    ' Table data
                    Dim vehicleName As String = If(.VehicleType = "Car", .SelectedCarName, .SelectedMotorName)
                    Dim description As String = $"{vehicleName} ({ .VehicleType})" & Chr(10) &
                                              $"Pickup: { .PickupDate:MMM dd, yyyy} { .PickupTime}" & Chr(10) &
                                              $"Return: { .ReturnDate:MMM dd, yyyy} { .ReturnTime}" & Chr(10) &
                                              $"From: { .PickupPlace}" & Chr(10) &
                                              $"To: { .ReturnPlace}"

                    Dim dataCell1 As New PdfPCell(New Phrase(description, infoFont))
                    dataCell1.Padding = 8
                    dataCell1.VerticalAlignment = Element.ALIGN_MIDDLE
                    detailTable.AddCell(dataCell1)

                    Dim dataCell2 As New PdfPCell(New Phrase(.RentalDurationDays.ToString(), infoFont))
                    dataCell2.HorizontalAlignment = Element.ALIGN_CENTER
                    dataCell2.Padding = 8
                    detailTable.AddCell(dataCell2)

                    Dim dataCell3 As New PdfPCell(New Phrase($"₱{ .DailyRate:N2}", infoFont))
                    dataCell3.HorizontalAlignment = Element.ALIGN_RIGHT
                    dataCell3.Padding = 8
                    detailTable.AddCell(dataCell3)

                    Dim subtotal As Decimal = .DailyRate * .RentalDurationDays
                    Dim dataCell4 As New PdfPCell(New Phrase($"₱{subtotal:N2}", infoFont))
                    dataCell4.HorizontalAlignment = Element.ALIGN_RIGHT
                    dataCell4.Padding = 8
                    detailTable.AddCell(dataCell4)

                    doc.Add(detailTable)
                    doc.Add(New Paragraph(" "))

                    ' Summary section
                    Dim summaryTable As New PdfPTable(2)
                    summaryTable.WidthPercentage = 100
                    summaryTable.SetWidths({3, 1})
                    summaryTable.DefaultCell.Border = Rectangle.NO_BORDER

                    ' Left side empty
                    summaryTable.AddCell("")

                    ' Right side - totals
                    Dim totalsTable As New PdfPTable(2)
                    totalsTable.WidthPercentage = 100
                    totalsTable.DefaultCell.Border = Rectangle.NO_BORDER
                    totalsTable.DefaultCell.PaddingBottom = 3

                    Dim vatAmount As Decimal = subtotal * 0.12D
                    Dim serviceAmount As Decimal = 100D

                    totalsTable.AddCell(New Phrase("Subtotal:", labelFont))
                    Dim subtotalCell As New PdfPCell(New Phrase($"₱{subtotal:N2}", infoFont))
                    subtotalCell.Border = Rectangle.NO_BORDER
                    subtotalCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    totalsTable.AddCell(subtotalCell)

                    totalsTable.AddCell(New Phrase("VAT (12%):", labelFont))
                    Dim vatCell As New PdfPCell(New Phrase($"₱{vatAmount:N2}", infoFont))
                    vatCell.Border = Rectangle.NO_BORDER
                    vatCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    totalsTable.AddCell(vatCell)

                    totalsTable.AddCell(New Phrase("Service Fee:", labelFont))
                    Dim serviceCell As New PdfPCell(New Phrase($"₱{serviceAmount:N2}", infoFont))
                    serviceCell.Border = Rectangle.NO_BORDER
                    serviceCell.HorizontalAlignment = Element.ALIGN_RIGHT
                    totalsTable.AddCell(serviceCell)

                    ' Total line
                    Dim totalCell1 As New PdfPCell(New Phrase("TOTAL AMOUNT:", totalFont))
                    totalCell1.Border = Rectangle.TOP_BORDER
                    totalCell1.BorderWidth = 1
                    totalCell1.PaddingTop = 8
                    totalsTable.AddCell(totalCell1)

                    Dim finalTotal As Decimal = .TotalAmount
                    Dim totalCell2 As New PdfPCell(New Phrase($"₱{finalTotal:N2}", totalFont))
                    totalCell2.Border = Rectangle.TOP_BORDER
                    totalCell2.BorderWidth = 1
                    totalCell2.HorizontalAlignment = Element.ALIGN_RIGHT
                    totalCell2.PaddingTop = 8
                    totalsTable.AddCell(totalCell2)

                    Dim summaryCell As New PdfPCell(totalsTable)
                    summaryCell.Border = Rectangle.NO_BORDER
                    summaryTable.AddCell(summaryCell)

                    doc.Add(summaryTable)
                    doc.Add(New Paragraph(" "))
                    doc.Add(New Paragraph(" "))

                    ' Payment info
                    doc.Add(New Paragraph("PAYMENT INFORMATION", headerFont))
                    doc.Add(New Paragraph(" "))

                    Dim paymentTable As New PdfPTable(2)
                    paymentTable.WidthPercentage = 100
                    paymentTable.SetWidths({1, 1})
                    paymentTable.DefaultCell.Border = Rectangle.NO_BORDER
                    paymentTable.DefaultCell.PaddingBottom = 5

                    paymentTable.AddCell(New Phrase("Payment Method:", labelFont))
                    paymentTable.AddCell(New Phrase(If(String.IsNullOrEmpty(.PaymentMethod), "Online Payment", .PaymentMethod), infoFont))
                    paymentTable.AddCell(New Phrase("Payment Status:", labelFont))
                    paymentTable.AddCell(New Phrase(If(String.IsNullOrEmpty(.PaymentStatus), "Paid", .PaymentStatus), infoFont))
                    paymentTable.AddCell(New Phrase("Transaction ID:", labelFont))
                    paymentTable.AddCell(New Phrase(If(String.IsNullOrEmpty(.PaymentReference), $"TXN-{DateTime.Now:yyyyMMdd}-{rentalId}", .PaymentReference), infoFont))

                    doc.Add(paymentTable)
                    doc.Add(New Paragraph(" "))
                    doc.Add(New Paragraph(" "))
                End With

                Dim line2 As New LineSeparator(1.0F, 100.0F, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1)
                doc.Add(New Chunk(line2))
                doc.Add(New Paragraph(" "))


                doc.Close()
                writer.Close()
            End Using

            MessageBox.Show($"RideExpress Invoice Created: {Path.GetFullPath(invoicePath)}")

        Catch ex As Exception
            MessageBox.Show("Error creating PDF from transaction data: " & ex.Message)
        End Try
    End Sub

End Module