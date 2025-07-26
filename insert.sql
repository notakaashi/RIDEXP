-- Additional INSERT statements for RIDEXP database
-- -----------------------------------------------------
-- Insert lookup table data
-- -----------------------------------------------------
INSERT INTO `transmission_types` (`transmission_type`) VALUES
('manual'),
('automatic'),
('cvt');

INSERT INTO fuel_types (fuel_type) VALUES
('Gasoline'),
( 'Diesel'),
('Electric'),
('Hybrid');

INSERT INTO `vehicle_status` (`status_name`) VALUES
('available'),
('rented'),
('under_maintenance'),
('out_of_service'),
('cleaning'),
('damaged');

INSERT INTO `payment_methods` (`method_name`) VALUES
('cash'),
('gcash'),
('card');

INSERT INTO `payment_status` (`status_name`) VALUES
('paid'),
('processing'),
('down_payment');

INSERT INTO `rental_status` (`status_name`) VALUES
('active'),
('completed'),
('cancelled');

INSERT INTO `maintenance_status` (`status_name`) VALUES
('scheduled'),
('in_progress'),
('completed');

INSERT INTO `user_roles` (`role_name`) VALUES
('admin'),
('customers');

INSERT INTO `inspection_types` (`inspection_type_name`) VALUES
('before_rent'),
('after_rent');


INSERT INTO car_category (category_name, description, transmission_id, fuel_id) VALUES
('Compact Sedan CVT', 'CVT sedans for city driving', 3, 1),
('MPV Automatic', 'Automatic multi-purpose vehicles', 2, 1),
('SUV Diesel Automatic', 'Diesel automatic sport utility vehicles', 2, 2),
('SUV Gasoline Automatic', 'Gasoline automatic sport utility vehicles', 2, 1),
('Hatchback CVT', 'CVT compact hatchback cars', 3, 1),
('Hybrid CVT', 'CVT fuel-efficient hybrid sedans', 3, 4);

-- Insert Motor Categories 
INSERT INTO motor_category (category_name, description, transmission_id, fuel_id, engine_capacity) VALUES
('Scooter CVT', 'CVT automatic scooters', 3, 1, '110-125cc'),
('Underbone Semi-Auto', 'Semi-automatic underbone motorcycles', 2, 1, '125cc'),
('Adventure CVT', 'CVT adventure-style scooters', 3, 1, '160cc');

-- Insert Cars 
INSERT INTO cars (car_category_id, make, model_name, year, license_plate, color, seating_capacity, mileage) VALUES
(1, 'Toyota', 'Vios ', 2023, 'ABC-1234', 'Red ', 5, 15000),
(2, 'Mitsubishi', 'Xpander', 2022, 'DEF-2345', 'Black a', 7, 22000),
(2, 'Toyota', 'Innova ', 2021, 'GHI-3456', 'White ', 8, 35000),
(2, 'Suzuki', 'Ertiga ', 2023, 'JKL-4567', 'White', 7, 18000),
(1, 'Honda', 'City ', 2022, 'MNO-5678', 'Red', 5, 28000),
(3, 'Toyota', 'Fortuner', 2021, 'PQR-6789', 'Black', 7, 45000),
(5, 'Suzuki', 'Swift', 2023, 'STU-7890', 'Red', 5, 12000),
(2, 'Honda', ' Civic', 2021, 'VWX-8901', 'Red', 7, 25000),
(6, 'Toyota', 'Corolla ', 2023, 'YZA-9012', 'Pearl', 5, 8000),
(4, 'Toyota', 'Rush ', 2022, 'BCD-0123', 'Silver ', 7, 32000);

-- Insert Motors
INSERT INTO motors (motor_category_id, make, model, year, license_plate, color, mileage) VALUES
(1, 'Yamaha', 'Mio Sporty', 2023, 'EFG-1134', 'Matte Blue', 8500),
(1, 'Yamaha', 'Mio Aerox 155 S', 2022, 'HIJ-1235', 'Black Raven', 12000),
(1, 'Honda', 'Click 125i', 2023, 'KLM-1336', 'Red', 6500),
(1, 'Honda', 'BeAT Premium ISS/CBS', 2022, 'NOP-1437', 'Matte Black', 11000),
(1, 'Honda', 'Genio', 2023, 'QRS-1538', 'Blue', 4200),
(1, 'Honda', 'PCX 160', 2023, 'XYZ-8888', 'White', 7000),
(2, 'Suzuki', 'Raider R150 Fi', 2022, 'WXY-1740', 'Blue', 18000),
(2, 'Kawasaki', 'Barako III', 2021, 'ZAB-1841', 'Black', 25000),
(1, 'Yamaha', 'NMAX 155 Standard', 2023, 'CDE-1942', 'Phantom Blue', 7800),
(3, 'Honda', 'ADV 160', 2022, 'FGH-2043', 'Matte Gunpowder Black', 13500);

-- Insert vehicles 

-- Cars 
INSERT INTO `vehicles` (`vehicle_type`, `item_id`, `status_id`) VALUES
('car', 1, 1), ('car', 2, 1), ('car', 3, 1), ('car', 4, 1), ('car', 5, 1),
('car', 6, 1), ('car', 7, 1), ('car', 8, 1), ('car', 9, 1), ('car', 10, 1);

-- Motors 
INSERT INTO `vehicles` (`vehicle_type`, `item_id`, `status_id`) VALUES
('motor', 1, 1), ('motor', 2, 1), ('motor', 3, 1), ('motor', 4, 1), ('motor', 5, 1),
('motor', 6, 1), ('motor', 7, 1), ('motor', 8, 1), ('motor', 9, 1), ('motor', 10, 1);

-- Insert terms and policie

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

6. YOUR RIGHTS: You may request access to, correction of, or deletion of your personal information.', 
'1.0', '2024-01-01'),

('Cancellation Policy', 
'1. RESERVATION CANCELLATION: Reservations may be cancelled up to 24 hours before the scheduled rental time without penalty.

2. CANCELLATION FEES: Cancellations made less than 24 hours before rental time are subject to a 50% cancellation fee.

3. NO-SHOW POLICY: Failure to pick up a reserved vehicle within 2 hours of scheduled time results in automatic cancellation and full charge.

4. REFUND PROCESSING: Refunds for eligible cancellations will be processed within 5-7 business days.

5. EMERGENCY CANCELLATIONS: In case of emergencies or unforeseen circumstances, please contact us immediately for special consideration.

6. WEATHER CANCELLATIONS: In case of severe weather conditions, we may cancel rentals for safety reasons with full refund.', 
'1.0', '2024-01-01'),

('Damage and Liability Policy',  '1. DAMAGE ASSESSMENT: All vehicles are inspected before and after rental. Any new damage will be documented and charged to the renter.

2. MINOR DAMAGE: Small scratches, dents, or interior stains may result in repair charges ranging from PHP 1,000 to PHP 10,000.

3. MAJOR DAMAGE: Significant damage may result in charges up to the full value of the vehicle.

4. THEFT PROTECTION: In case of vehicle theft, the renter may be liable for the full value of the vehicle.

5. ACCIDENT PROCEDURES: In case of an accident, immediately contact local authorities and our 24-hour emergency hotline.

6. INSURANCE CLAIMS: We will assist with insurance claims, but the renter remains responsible for deductibles and uncovered damages.

7. DISPUTE RESOLUTION: Any disputes regarding damage charges will be resolved through our internal review process.', 
'1.0', '2024-01-01');


-- Insert rental rates for motorcycles (vehicle_id 1-10)
INSERT INTO rental_rate (vehicle_id, rate_per_day,  effective_date) VALUES
-- Yamaha Mio Sporty (Budget scooter)
(1,  600.00,  '2024-01-01'),
-- Yamaha Mio Aerox 155 S (Sport scooter)
(2,  900.00,  '2024-01-01'),
-- Honda Click 125i (Premium scooter)
(3, 750.00,  '2024-01-01'),
-- Honda BeAT Premium (Budget scooter)
(4, 650.00,  '2024-01-01'),
-- Honda Genio (Budget scooter)
(5,  700.00, '2024-01-01'),
-- Honda Super Cub C125 (Classic/Premium)
(6,  800.00,  '2024-01-01'),
-- Suzuki Raider R150 Fi (Sport manual)
(7,  1000.00,  '2024-01-01'),
-- Kawasaki Barako III (Sport manual)
(8,  1100.00, '2024-01-01'),
-- Yamaha NMAX 155 (Premium scooter)
(9,  1200.00, '2024-01-01'),
-- Honda ADV 160 (Adventure premium)
(10, 1300.00,  '2024-01-01');

-- Insert rental rates for cars (vehicle_id 11-20)
INSERT INTO rental_rate (vehicle_id,  rate_per_day, effective_date) VALUES
-- Toyota Vios (Compact sedan)
(11, 1800.00, '2024-01-01'),
-- Mitsubishi Xpander (MPV)
(12,  2500.00, '2024-01-01'),
-- Toyota Innova Diesel (Premium MPV)
(13, 3200.00,  '2024-01-01'),
-- Suzuki Ertiga (Compact MPV)
(14, 2200.00,  '2024-01-01'),
-- Honda City (Compact sedan)
(15,  2000.00,  '2024-01-01'),
-- Toyota Fortuner (Premium SUV)
(16,  4000.00,  '2024-01-01'),
-- Suzuki Swift (Hatchback)
(17,  1600.00, '2024-01-01'),
-- Honda  Civic Type R VTEC 
(18,  2400.00,  '2024-01-01'),
-- Toyota Corolla Altis Hybrid (Premium sedan)
(19, 2800.00,  '2024-01-01'),
-- Toyota Rush (Compact SUV)
(20,  2500.00,  '2024-01-01');

INSERT INTO user (username, password_hash, role_id, created_at)
VALUES 
  ('JONEL', SHA2('admin', 256), 1, NOW()),
  ('MARCUS', SHA2('admin', 256), 1, NOW());

INSERT INTO cars_pic (car_id, image) VALUES (1, 'vios');
INSERT INTO cars_pic (car_id, image) VALUES (2, 'xpander');
INSERT INTO cars_pic (car_id, image) VALUES (3, 'innova');
INSERT INTO cars_pic (car_id, image) VALUES (4, 'ertiga');
INSERT INTO cars_pic (car_id, image) VALUES (5, 'city');
INSERT INTO cars_pic (car_id, image) VALUES (6, 'fortuner');
INSERT INTO cars_pic (car_id, image) VALUES (7, 'swift');
INSERT INTO cars_pic (car_id, image) VALUES (8, 'civic');
INSERT INTO cars_pic (car_id, image) VALUES (9, 'corolla');
INSERT INTO cars_pic (car_id, image) VALUES (10, 'rush');

INSERT INTO motors_pic (motor_id, image) VALUES
(1, 'imgSporty'),
(2, 'imgAerox'),
(3, 'imgClick'),
(4, 'imgBeat'),
(5, 'imgGenio'),
(6, 'imgPCX'),
(7, 'imgRaider'),
(8, 'imgBarako'),
(9, 'imgNMAX'),
(10, 'imgADV');
