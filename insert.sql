-- Additional INSERT statements for RIDEXP database

-- Add more payment methods
INSERT INTO `payment_methods` (`method_name`) VALUES
('bank_transfer'),
('check'),
('credit_card'),
('debit_card'),
('paypal'),
('online_banking');

-- Add customer role to user_roles
INSERT INTO `user_roles` (`role_name`) VALUES
('customer');

-- Insert car categories (typical Filipino car categories)
INSERT INTO `car_category` (`category_name`, `description`, `transmission_id`, `fuel_id`) VALUES
('Compact Sedan', 'Popular entry-level sedans for daily driving', 1, 1),
('Subcompact', 'Small cars perfect for city driving and parking', 1, 1),
('Mid-size Sedan', 'Comfortable sedans for longer trips', 2, 1),
('Full-size Sedan', 'Premium sedans with more space', 2, 1),
('SUV', 'Sport Utility Vehicles for families', 2, 1),
('Hatchback', 'Compact cars with flexible cargo space', 1, 1),
('Electric', 'Eco-friendly electric vehicles', 2, 3),
('Hybrid', 'Fuel-efficient hybrid vehicles', 2, 4);

-- Insert motor categories (typical Filipino motorcycle categories)
INSERT INTO `motor_category` (`category_name`, `description`, `transmission_id`, `fuel_id`, `engine_capacity`) VALUES
('Scooter', 'Automatic scooters perfect for city commuting', 2, 1, '125cc-150cc'),
('Underbone', 'Sport-style underbone motorcycles', 1, 1, '150cc'),
('Naked', 'Naked sport bikes for enthusiasts', 1, 1, '150cc'),
('Enduro', 'Dual-sport motorcycles for city and off-road', 1, 1, '125cc'),
('Standard', 'Basic motorcycles for everyday use', 1, 1, '150cc');

-- Insert sample cars (typical Filipino go-to vehicles)
INSERT INTO `cars` (`car_category_id`, `make`, `model_name`, `year`, `license_plate`, `color`, `seating_capacity`, `mileage`, `status_id`) VALUES
(1, 'Toyota', 'Vios', 2022, 'ABC-1234', 'White', 5, 15000, 1),
(1, 'Toyota', 'Vios', 2023, 'DEF-5678', 'Silver', 5, 8000, 1),
(1, 'Honda', 'City', 2022, 'GHI-9012', 'Blue', 5, 12000, 1),
(1, 'Honda', 'City', 2023, 'JKL-3456', 'Red', 5, 5000, 1),
(2, 'Nissan', 'Almera', 2022, 'MNO-7890', 'Black', 5, 18000, 1),
(2, 'Mitsubishi', 'Mirage', 2023, 'PQR-1234', 'Gray', 5, 10000, 1),
(2, 'Suzuki', 'Swift', 2022, 'STU-5678', 'White', 5, 20000, 1),
(3, 'Honda', 'Civic', 2022, 'VWX-9012', 'Black', 5, 15000, 1),
(3, 'Honda', 'Civic', 2023, 'YZA-3456', 'Silver', 5, 12000, 1),
(3, 'Toyota', 'Altis', 2023, 'BCD-7890', 'Blue', 5, 8000, 1),
(4, 'Honda', 'Accord', 2022, 'EFG-1234', 'White', 5, 25000, 1),
(4, 'Toyota', 'Camry', 2023, 'HIJ-5678', 'Black', 5, 15000, 1),
(5, 'Honda', 'CR-V', 2022, 'KLM-9012', 'Silver', 7, 30000, 1),
(5, 'Toyota', 'Fortuner', 2023, 'NOP-3456', 'White', 7, 18000, 1),
(5, 'Mitsubishi', 'Montero Sport', 2022, 'QRS-7890', 'Gray', 7, 22000, 1);

-- Insert sample motors (typical Filipino motorcycles/scooters)
INSERT INTO `motors` (`motor_category_id`, `make`, `model`, `year`, `license_plate`, `color`, `mileage`, `status_id`) VALUES
(1, 'Yamaha', 'Mio i 125', 2022, 'M001-ABC', 'White', 8000, 1),
(1, 'Yamaha', 'Mio i 125', 2023, 'M002-DEF', 'Blue', 5000, 1),
(1, 'Honda', 'Click 150i', 2022, 'M003-GHI', 'Red', 12000, 1),
(1, 'Honda', 'Click 150i', 2023, 'M004-JKL', 'Black', 6000, 1),
(1, 'Yamaha', 'NMAX', 2022, 'M005-MNO', 'Gray', 10000, 1),
(1, 'Yamaha', 'NMAX', 2023, 'M006-PQR', 'White', 3000, 1),
(1, 'Honda', 'PCX 150', 2022, 'M007-STU', 'Silver', 15000, 1),
(1, 'Honda', 'PCX 150', 2023, 'M008-VWX', 'Blue', 8000, 1),
(2, 'Yamaha', 'Sniper 150', 2022, 'M009-YZA', 'Red', 12000, 1),
(2, 'Honda', 'RS150', 2023, 'M010-BCD', 'Black', 5000, 1),
(3, 'Honda', 'CB150R', 2022, 'M011-EFG', 'Orange', 18000, 1),
(3, 'Yamaha', 'MT-15', 2023, 'M012-HIJ', 'Blue', 7000, 1),
(4, 'Honda', 'XRM 125', 2022, 'M013-KLM', 'Red', 20000, 1),
(4, 'Yamaha', 'XTZ 125', 2023, 'M014-NOP', 'Green', 15000, 1),
(5, 'Suzuki', 'Raider R150', 2022, 'M015-QRS', 'Blue', 25000, 1);

-- Insert vehicles (linking cars and motors to unified vehicle table)
-- Cars
INSERT INTO `vehicles` (`vehicle_type`, `item_id`) VALUES
('car', 1), ('car', 2), ('car', 3), ('car', 4), ('car', 5),
('car', 6), ('car', 7), ('car', 8), ('car', 9), ('car', 10),
('car', 11), ('car', 12), ('car', 13), ('car', 14), ('car', 15);

-- Motors
INSERT INTO `vehicles` (`vehicle_type`, `item_id`) VALUES
('motor', 1), ('motor', 2), ('motor', 3), ('motor', 4), ('motor', 5),
('motor', 6), ('motor', 7), ('motor', 8), ('motor', 9), ('motor', 10),
('motor', 11), ('motor', 12), ('motor', 13), ('motor', 14), ('motor', 15);

-- Insert sample terms and policies
INSERT INTO `terms_and_policies` (`title`, `content`, `version`, `effective_date`) VALUES
('Rental Agreement Terms', 
'1. RENTAL PERIOD: The rental period begins when the vehicle is delivered to the renter and ends when the vehicle is returned to the rental location.

2. DRIVER REQUIREMENTS: The renter must be at least 21 years old and possess a valid driver\'s license. For motorcycles, appropriate motorcycle license is required.

3. VEHICLE CONDITION: The renter agrees to return the vehicle in the same condition as received, normal wear and tear excepted.

4. PROHIBITED USES: The vehicle may not be used for racing, off-road driving (unless specifically rented for such purpose), or any illegal activities.

5. INSURANCE: Basic insurance is included. Additional coverage options are available for purchase.

6. FUEL POLICY: Vehicle must be returned with the same fuel level as when rented, or fuel charges will apply.

7. LATE RETURNS: Late return fees apply for vehicles returned after the agreed time.

8. DAMAGE RESPONSIBILITY: Renter is responsible for any damage to the vehicle during the rental period.', 
'1.0', '2024-01-01'),

('Privacy Policy', 
'1. INFORMATION COLLECTION: We collect personal information necessary for vehicle rental services including name, contact details, and driver\'s license information.

2. USE OF INFORMATION: Your information is used to process rentals, communicate with you, and ensure vehicle security.

3. DATA SECURITY: We implement appropriate security measures to protect your personal information.

4. INFORMATION SHARING: We do not sell or share your personal information with third parties except as required by law.

5. DATA RETENTION: We retain your information for as long as necessary to provide services and comply with legal requirements.

6. YOUR RIGHTS: You may request access to, correction of, or deletion of your personal information.

7. CONTACT: For privacy-related questions, contact us at privacy@ridexp.com', 
'1.0', '2024-01-01'),

('Cancellation Policy', 
'1. RESERVATION CANCELLATION: Reservations may be cancelled up to 24 hours before the scheduled rental time without penalty.

2. CANCELLATION FEES: Cancellations made less than 24 hours before rental time are subject to a 50% cancellation fee.

3. NO-SHOW POLICY: Failure to pick up a reserved vehicle within 2 hours of scheduled time results in automatic cancellation and full charge.

4. REFUND PROCESSING: Refunds for eligible cancellations will be processed within 5-7 business days.

5. EMERGENCY CANCELLATIONS: In case of emergencies or unforeseen circumstances, please contact us immediately for special consideration.

6. WEATHER CANCELLATIONS: In case of severe weather conditions, we may cancel rentals for safety reasons with full refund.', 
'1.0', '2024-01-01'),

('Damage and Liability Policy', 
'1. DAMAGE ASSESSMENT: All vehicles are inspected before and after rental. Any new damage will be documented and charged to the renter.

2. MINOR DAMAGE: Small scratches, dents, or interior stains may result in repair charges ranging from PHP 1,000 to PHP 10,000.

3. MAJOR DAMAGE: Significant damage may result in charges up to the full value of the vehicle.

4. THEFT PROTECTION: In case of vehicle theft, the renter may be liable for the full value of the vehicle unless comprehensive insurance was purchased.

5. ACCIDENT PROCEDURES: In case of an accident, immediately contact local authorities and our 24-hour emergency hotline.

6. INSURANCE CLAIMS: We will assist with insurance claims, but the renter remains responsible for deductibles and uncovered damages.

7. DISPUTE RESOLUTION: Any disputes regarding damage charges will be resolved through our internal review process.', 
'1.0', '2024-01-01');