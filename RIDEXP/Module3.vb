Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports MySql.Data.MySqlClient

Public Module Module3

    Public Sub GenerateRideExpressInvoice(rentalId As Integer)
        Try
            If RentalTransactionModule.TransactionData.CustomerId > 0 Then
                CreatePDFInvoice(rentalId)
            Else
                MessageBox.Show("No transaction data found. Invoice can only be created immediately after a rental.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating invoice: " & ex.Message)
        End Try
    End Sub

    Public Sub GenerateInvoiceFromCurrentTransaction(rentalId As Integer)
        Try
            CreatePDFInvoice(rentalId)
        Catch ex As Exception
            MessageBox.Show("Error generating invoice from transaction data: " & ex.Message)
        End Try
    End Sub

    Private Sub CreatePDFInvoice(rentalId As Integer)
        Try
            Dim data = RentalTransactionModule.TransactionData

            Dim customerInfo = GetCustomerInfo(data.CustomerId)

            Dim vehicleInfo = GetVehicleInfo(data.SelectedVehicleId)

            Dim invoicePath As String = $"RideExpress_Invoice_{rentalId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"

            Using fs As New FileStream(invoicePath, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim doc As New Document(PageSize.A4, 30, 30, 30, 30)
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
                doc.Open()

                Dim titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.DARK_GRAY)
                Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)
                Dim labelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.DARK_GRAY)
                Dim infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK)
                Dim totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)

                Dim companyTable As New PdfPTable(2)
                companyTable.WidthPercentage = 100
                companyTable.SetWidths({3, 1})
                companyTable.DefaultCell.Border = Rectangle.NO_BORDER
                companyTable.SpacingAfter = 10

                Dim companyCell As New PdfPCell()
                companyCell.Border = Rectangle.NO_BORDER
                companyCell.AddElement(New Paragraph("RIDEXPRESS", titleFont))
                companyCell.AddElement(New Paragraph("RDXP Ave, Taguig City", infoFont))
                companyCell.AddElement(New Paragraph("Metro Manila, Philippines 1630", infoFont))
                companyCell.AddElement(New Paragraph("Phone: +6399 946 9090", infoFont))
                companyCell.AddElement(New Paragraph("Email: rentals@ridexpress.com", infoFont))
                companyTable.AddCell(companyCell)

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

                Dim line As New LineSeparator(1.0F, 100.0F, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1)
                doc.Add(New Chunk(line))
                doc.Add(New Paragraph(" "))

                doc.Add(New Paragraph("CUSTOMER INFORMATION", headerFont))
                doc.Add(New Paragraph(" "))

                Dim customerTable As New PdfPTable(2)
                customerTable.WidthPercentage = 100
                customerTable.SetWidths({1, 1})
                customerTable.DefaultCell.Border = Rectangle.NO_BORDER
                customerTable.DefaultCell.PaddingBottom = 3
                customerTable.SpacingAfter = 10

                customerTable.AddCell(New Phrase("Customer Name:", labelFont))
                customerTable.AddCell(New Phrase(If(customerInfo.Name, "N/A"), infoFont))

                customerTable.AddCell(New Phrase("Contact Number:", labelFont))
                customerTable.AddCell(New Phrase(If(customerInfo.Phone, "N/A"), infoFont))

                customerTable.AddCell(New Phrase("Email:", labelFont))
                customerTable.AddCell(New Phrase(If(customerInfo.Email, "N/A"), infoFont))

                customerTable.AddCell(New Phrase("Address:", labelFont))
                customerTable.AddCell(New Phrase(If(customerInfo.Address, "N/A"), infoFont))

                customerTable.AddCell(New Phrase("Rental ID:", labelFont))
                customerTable.AddCell(New Phrase(rentalId.ToString(), infoFont))

                doc.Add(customerTable)

                doc.Add(New Paragraph("RENTAL DETAILS", headerFont))
                doc.Add(New Paragraph(" "))

                Dim detailTable As New PdfPTable(4)
                detailTable.WidthPercentage = 100
                detailTable.SetWidths({3, 1, 1, 1})
                detailTable.SpacingAfter = 10


                Dim headerCell1 As New PdfPCell(New Phrase("Description", labelFont)) With {
                    .BackgroundColor = BaseColor.LIGHT_GRAY,
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .Padding = 5
                }
                detailTable.AddCell(headerCell1)

                Dim headerCell2 As New PdfPCell(New Phrase("Days", labelFont)) With {
                    .BackgroundColor = BaseColor.LIGHT_GRAY,
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .Padding = 5
                }
                detailTable.AddCell(headerCell2)

                Dim headerCell3 As New PdfPCell(New Phrase("Rate/Day", labelFont)) With {
                    .BackgroundColor = BaseColor.LIGHT_GRAY,
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .Padding = 5
                }
                detailTable.AddCell(headerCell3)

                Dim headerCell4 As New PdfPCell(New Phrase("Amount", labelFont)) With {
                    .BackgroundColor = BaseColor.LIGHT_GRAY,
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .Padding = 5
                }
                detailTable.AddCell(headerCell4)

                Dim vehicleDescription As String = ""
                If Not String.IsNullOrEmpty(vehicleInfo.Make) AndAlso vehicleInfo.Make <> "Unknown" AndAlso
                   Not String.IsNullOrEmpty(vehicleInfo.Model) AndAlso vehicleInfo.Model <> "Unknown" Then
                    vehicleDescription = $"{vehicleInfo.Make} {vehicleInfo.Model} ({vehicleInfo.VehicleType})"
                Else
                    Dim fallbackName As String = If(data.VehicleType.ToLower() = "car", data.SelectedCarName, data.SelectedMotorName)
                    vehicleDescription = $"{fallbackName} ({data.VehicleType})"
                End If

                Dim description As String = vehicleDescription & vbCrLf &
                                            $"Pickup: {data.PickupDate:MMM dd, yyyy} {data.PickupTime}" & vbCrLf &
                                            $"Return: {data.ReturnDate:MMM dd, yyyy} {data.ReturnTime}" & vbCrLf &
                                            $"From: {data.PickupPlace}" & vbCrLf &
                                            $"To: {data.ReturnPlace}"

                Dim dataCell1 As New PdfPCell(New Phrase(description, infoFont)) With {.Padding = 5}
                detailTable.AddCell(dataCell1)

                Dim dataCell2 As New PdfPCell(New Phrase(data.RentalDurationDays.ToString(), infoFont)) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .Padding = 5
                }
                detailTable.AddCell(dataCell2)

                Dim dataCell3 As New PdfPCell(New Phrase($"₱{data.DailyRate:N2}", infoFont)) With {
                    .HorizontalAlignment = Element.ALIGN_RIGHT,
                    .Padding = 5
                }
                detailTable.AddCell(dataCell3)

                Dim subtotal As Decimal = data.DailyRate * data.RentalDurationDays
                Dim dataCell4 As New PdfPCell(New Phrase($"₱{subtotal:N2}", infoFont)) With {
                    .HorizontalAlignment = Element.ALIGN_RIGHT,
                    .Padding = 5
                }
                detailTable.AddCell(dataCell4)

                doc.Add(detailTable)

                Dim summaryTable As New PdfPTable(2)
                summaryTable.WidthPercentage = 100
                summaryTable.SetWidths({3, 1})
                summaryTable.DefaultCell.Border = Rectangle.NO_BORDER
                summaryTable.SpacingAfter = 10

                summaryTable.AddCell("")

                Dim totalsTable As New PdfPTable(2)
                totalsTable.WidthPercentage = 100
                totalsTable.DefaultCell.Border = Rectangle.NO_BORDER
                totalsTable.DefaultCell.PaddingBottom = 2

                Dim vatAmount As Decimal = subtotal * 0.12D
                Dim serviceAmount As Decimal = 100D
                Dim calculatedTotal As Decimal = subtotal + vatAmount + serviceAmount
                Dim totalAmount As Decimal = calculatedTotal

                totalsTable.AddCell(New Phrase("Subtotal:", labelFont))
                totalsTable.AddCell(New PdfPCell(New Phrase($"₱{subtotal:N2}", infoFont)) With {
                    .Border = Rectangle.NO_BORDER,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })

                totalsTable.AddCell(New Phrase("VAT (12%):", labelFont))
                totalsTable.AddCell(New PdfPCell(New Phrase($"₱{vatAmount:N2}", infoFont)) With {
                    .Border = Rectangle.NO_BORDER,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })

                totalsTable.AddCell(New Phrase("Service Fee:", labelFont))
                totalsTable.AddCell(New PdfPCell(New Phrase($"₱{serviceAmount:N2}", infoFont)) With {
                    .Border = Rectangle.NO_BORDER,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })

                totalsTable.AddCell(New PdfPCell(New Phrase("TOTAL AMOUNT:", totalFont)) With {
                    .Border = Rectangle.TOP_BORDER,
                    .BorderWidth = 1,
                    .PaddingTop = 5
                })
                totalsTable.AddCell(New PdfPCell(New Phrase($"₱{totalAmount:N2}", totalFont)) With {
                    .Border = Rectangle.TOP_BORDER,
                    .BorderWidth = 1,
                    .HorizontalAlignment = Element.ALIGN_RIGHT,
                    .PaddingTop = 5
                })

                summaryTable.AddCell(New PdfPCell(totalsTable) With {.Border = Rectangle.NO_BORDER})
                doc.Add(summaryTable)

                doc.Add(New Paragraph("PAYMENT INFORMATION", headerFont))
                doc.Add(New Paragraph(" "))

                Dim paymentTable As New PdfPTable(2)
                paymentTable.WidthPercentage = 100
                paymentTable.SetWidths({1, 1})
                paymentTable.DefaultCell.Border = Rectangle.NO_BORDER
                paymentTable.DefaultCell.PaddingBottom = 3
                paymentTable.SpacingAfter = 15

                paymentTable.AddCell(New Phrase("Payment Method:", labelFont))
                paymentTable.AddCell(New Phrase(If(String.IsNullOrEmpty(data.PaymentMethod), "Online Payment", data.PaymentMethod), infoFont))

                paymentTable.AddCell(New Phrase("Payment Status:", labelFont))
                paymentTable.AddCell(New Phrase(If(String.IsNullOrEmpty(data.PaymentStatus), "Paid", data.PaymentStatus), infoFont))

                paymentTable.AddCell(New Phrase("Transaction ID:", labelFont))
                paymentTable.AddCell(New Phrase(If(String.IsNullOrEmpty(data.PaymentReference),
                                                  $"TXN-{DateTime.Now:yyyyMMdd}-{rentalId}",
                                                  data.PaymentReference), infoFont))

                doc.Add(paymentTable)

                doc.Add(New Chunk(line))
                doc.Add(New Paragraph(" "))

                Dim footerPara As New Paragraph("Thank you for choosing RideExpress!", infoFont)
                footerPara.Alignment = Element.ALIGN_CENTER
                footerPara.SpacingAfter = 5
                doc.Add(footerPara)

                Dim footerNote As New Paragraph("For inquiries, please contact us at rentals@ridexpress.com or call +63 2 987-6543", infoFont)
                footerNote.Alignment = Element.ALIGN_CENTER
                doc.Add(footerNote)

                doc.Close()
                writer.Close()
            End Using

            RentalTransactionModule.ClearTransactionData()

        Catch ex As Exception
            MessageBox.Show("Error creating PDF: " & ex.Message)
        End Try
    End Sub

    Private Function GetCustomerInfo(customerId As Integer) As Object
        Try
            Using conn As New MySqlConnection("server=localhost;userid=root;password=;database=ridexp;Convert Zero Datetime=True;Allow Zero Datetime=True;")
                conn.Open()

                Dim query As String = "SELECT first_name, last_name, phone, email, address FROM customers WHERE customer_id = @customer_id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@customer_id", customerId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim firstName As String = If(IsDBNull(reader("first_name")), "", reader("first_name").ToString())
                            Dim lastName As String = If(IsDBNull(reader("last_name")), "", reader("last_name").ToString())
                            Dim fullName As String = $"{firstName} {lastName}".Trim()

                            Return New With {
                                .Name = If(String.IsNullOrEmpty(fullName), Nothing, fullName),
                                .Phone = If(IsDBNull(reader("phone")), Nothing, reader("phone").ToString()),
                                .Email = If(IsDBNull(reader("email")), Nothing, reader("email").ToString()),
                                .Address = If(IsDBNull(reader("address")), Nothing, reader("address").ToString())
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not retrieve customer information: " & ex.Message)
        End Try

        Return New With {
            .Name = Nothing,
            .Phone = Nothing,
            .Email = Nothing,
            .Address = Nothing
        }
    End Function

    Private Function GetVehicleInfo(vehicleId As Integer) As Object
        Try
            Using conn As New MySqlConnection("server=localhost;userid=root;password=;database=ridexp;Convert Zero Datetime=True;Allow Zero Datetime=True;")
                conn.Open()

                Dim query As String = "
                    SELECT 
                        v.vehicle_type,
                        CASE 
                            WHEN v.vehicle_type = 'car' THEN CONCAT(c.make, ' ', c.model_name)
                            WHEN v.vehicle_type = 'motor' THEN CONCAT(m.make, ' ', m.model)
                            ELSE 'Unknown Vehicle'
                        END as vehicle_full_name,
                        CASE 
                            WHEN v.vehicle_type = 'car' THEN c.make
                            WHEN v.vehicle_type = 'motor' THEN m.make
                            ELSE 'Unknown'
                        END as make,
                        CASE 
                            WHEN v.vehicle_type = 'car' THEN c.model_name
                            WHEN v.vehicle_type = 'motor' THEN m.model
                            ELSE 'Unknown'
                        END as model
                    FROM vehicles v
                    LEFT JOIN cars c ON (v.vehicle_type = 'car' AND v.item_id = c.car_id)
                    LEFT JOIN motors m ON (v.vehicle_type = 'motor' AND v.item_id = m.motor_id)
                    WHERE v.vehicle_id = @vehicle_id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@vehicle_id", vehicleId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New With {
                                .VehicleType = If(IsDBNull(reader("vehicle_type")), "Unknown", reader("vehicle_type").ToString()),
                                .FullName = If(IsDBNull(reader("vehicle_full_name")), "Unknown Vehicle", reader("vehicle_full_name").ToString()),
                                .Make = If(IsDBNull(reader("make")) OrElse String.IsNullOrEmpty(reader("make").ToString()), Nothing, reader("make").ToString()),
                                .Model = If(IsDBNull(reader("model")) OrElse String.IsNullOrEmpty(reader("model").ToString()), Nothing, reader("model").ToString())
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' If database query fails, return default values
            Console.WriteLine("Could not retrieve vehicle information: " & ex.Message)
        End Try

        ' Return default vehicle info if query fails
        Return New With {
            .VehicleType = "Unknown",
            .FullName = Nothing,
            .Make = Nothing,
            .Model = Nothing
        }
    End Function

End Module