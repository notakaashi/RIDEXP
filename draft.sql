-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema RIDEXP
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `RIDEXP` DEFAULT CHARACTER SET utf8 ;
USE `RIDEXP`;

-- -----------------------------------------------------
-- Table `transmission_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `transmission_types` (
  `transmission_id` INT NOT NULL AUTO_INCREMENT,
  `transmission_type` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`transmission_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `fuel_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fuel_types` (
  `fuel_id` INT NOT NULL AUTO_INCREMENT,
  `fuel_type` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`fuel_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `vehicle_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vehicle_status` (
  `status_id` INT NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `payment_methods`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `payment_methods` (
  `method_id` INT NOT NULL AUTO_INCREMENT,
  `method_name` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`method_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `payment_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `payment_status` (
  `payment_status_id` INT NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`payment_status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rental_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rental_status` (
  `rental_status_id` INT NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`rental_status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `reservation_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `reservation_status` (
  `reservation_status_id` INT NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`reservation_status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `maintenance_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `maintenance_status` (
  `maintenance_status_id` INT NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`maintenance_status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `user_roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `user_roles` (
  `role_id` INT NOT NULL AUTO_INCREMENT,
  `role_name` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`role_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `inspection_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `inspection_types` (
  `inspection_type_id` INT NOT NULL AUTO_INCREMENT,
  `inspection_type_name` VARCHAR(20) NOT NULL UNIQUE,
  PRIMARY KEY (`inspection_type_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `car_category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_category` (
  `car_category_id` INT NOT NULL AUTO_INCREMENT,
  `category_name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(100) NOT NULL,
  `transmission_id` INT,
  `fuel_id` INT,
  PRIMARY KEY (`car_category_id`),
  FOREIGN KEY (`transmission_id`) REFERENCES `transmission_types`(`transmission_id`),
  FOREIGN KEY (`fuel_id`) REFERENCES `fuel_types`(`fuel_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `cars`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cars` (
  `car_id` INT NOT NULL AUTO_INCREMENT,
  `car_category_id` INT NOT NULL,
  `make` VARCHAR(45) NOT NULL,
  `model_name` VARCHAR(45) NOT NULL,
  `year` INT NOT NULL,
  `license_plate` VARCHAR(45) NOT NULL UNIQUE,
  `color` VARCHAR(30),
  `seating_capacity` INT,
  `mileage` INT DEFAULT 0,
  `status_id` INT NOT NULL,
  PRIMARY KEY (`car_id`),
  FOREIGN KEY (`car_category_id`) REFERENCES `car_category`(`car_category_id`),
  FOREIGN KEY (`status_id`) REFERENCES `vehicle_status`(`status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `motor_category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `motor_category` (
  `motor_category_id` INT NOT NULL AUTO_INCREMENT,
  `category_name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(100) NOT NULL,
  `transmission_id` INT NOT NULL,
  `fuel_id` INT,
  `engine_capacity` VARCHAR(20),
  PRIMARY KEY (`motor_category_id`),
  FOREIGN KEY (`transmission_id`) REFERENCES `transmission_types`(`transmission_id`),
  FOREIGN KEY (`fuel_id`) REFERENCES `fuel_types`(`fuel_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `motors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `motors` (
  `motor_id` INT NOT NULL AUTO_INCREMENT,
  `motor_category_id` INT NOT NULL,
  `make` VARCHAR(45) NOT NULL,
  `model` VARCHAR(45),
  `year` INT NOT NULL,
  `license_plate` VARCHAR(45) NOT NULL UNIQUE,
  `color` VARCHAR(30),
  `mileage` INT DEFAULT 0,
  `status_id` INT NOT NULL,
  PRIMARY KEY (`motor_id`),
  FOREIGN KEY (`motor_category_id`) REFERENCES `motor_category`(`motor_category_id`),
  FOREIGN KEY (`status_id`) REFERENCES `vehicle_status`(`status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `vehicles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vehicles` (
  `vehicle_id` INT NOT NULL AUTO_INCREMENT,
  `vehicle_type` ENUM('car', 'motor') NOT NULL,
  `item_id` INT NOT NULL,
  PRIMARY KEY (`vehicle_id`),
  UNIQUE KEY `unique_vehicle` (`vehicle_type`, `item_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `customers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `customers` (
  `customer_id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `date_of_birth` DATE NOT NULL,
  `email` VARCHAR(100) NOT NULL UNIQUE,
  `phone` VARCHAR(20),
  `address` VARCHAR(255) NOT NULL,
  `license_number` VARCHAR(50),
  `license_expiry` DATE,
  PRIMARY KEY (`customer_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rental_rate`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rental_rate` (
  `rate_id` INT NOT NULL AUTO_INCREMENT,
  `vehicle_id` INT NOT NULL,
  `rate_per_hour` DECIMAL(10,2) NOT NULL,
  `rate_per_day` DECIMAL(10,2),
  `security_deposit` DECIMAL(10,2) NOT NULL,
  `effective_date` DATE NOT NULL,
  PRIMARY KEY (`rate_id`),
  FOREIGN KEY (`vehicle_id`) REFERENCES `vehicles`(`vehicle_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `reservation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `reservation` (
  `reservation_id` INT NOT NULL AUTO_INCREMENT,
  `customer_id` INT NOT NULL,
  `vehicle_id` INT NOT NULL,
  `start_datetime` DATETIME NOT NULL,
  `end_datetime` DATETIME NOT NULL,
  `total_amount` DECIMAL(10,2),
  `reservation_status_id` INT NOT NULL,
  PRIMARY KEY (`reservation_id`),
  FOREIGN KEY (`customer_id`) REFERENCES `customers`(`customer_id`),
  FOREIGN KEY (`vehicle_id`) REFERENCES `vehicles`(`vehicle_id`),
  FOREIGN KEY (`reservation_status_id`) REFERENCES `reservation_status`(`reservation_status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rentals`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rentals` (
  `rental_id` INT NOT NULL AUTO_INCREMENT,
  `reservation_id` INT NULL,
  `start_date` DATETIME NOT NULL,
  `end_date` DATETIME NOT NULL,
  `actual_return_date` DATETIME,
  `customer_id` INT NOT NULL,
  `vehicle_id` INT NOT NULL,
  `total_amount` DECIMAL(10,2),
  `security_deposit` DECIMAL(10,2),
  `rental_status_id` INT NOT NULL,
  PRIMARY KEY (`rental_id`),
  FOREIGN KEY (`customer_id`) REFERENCES `customers`(`customer_id`),
  FOREIGN KEY (`vehicle_id`) REFERENCES `vehicles`(`vehicle_id`),
  FOREIGN KEY (`reservation_id`) REFERENCES `reservation`(`reservation_id`),
  FOREIGN KEY (`rental_status_id`) REFERENCES `rental_status`(`rental_status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `payment` (
  `payment_id` INT NOT NULL AUTO_INCREMENT,
  `rental_id` INT NOT NULL,
  `amount` DECIMAL(10,2) NOT NULL,
  `payment_status_id` INT NOT NULL,
  `method_id` INT NOT NULL,
  `paid_at` DATETIME,
  PRIMARY KEY (`payment_id`),
  FOREIGN KEY (`rental_id`) REFERENCES `rentals`(`rental_id`),
  FOREIGN KEY (`payment_status_id`) REFERENCES `payment_status`(`payment_status_id`),
  FOREIGN KEY (`method_id`) REFERENCES `payment_methods`(`method_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `penalty`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `penalty` (
  `penalty_id` INT NOT NULL AUTO_INCREMENT,
  `rental_id` INT NOT NULL,
  `description` TEXT NOT NULL,
  `amount` DECIMAL(10,2) NOT NULL,
  `is_paid` BOOLEAN DEFAULT FALSE,
  PRIMARY KEY (`penalty_id`),
  FOREIGN KEY (`rental_id`) REFERENCES `rentals`(`rental_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `checklist`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `checklist` (
  `checklist_id` INT NOT NULL AUTO_INCREMENT,
  `rental_id` INT NOT NULL,
  `inspection_date` DATE NOT NULL,
  `inspection_type_id` INT NOT NULL,
  `windows_condition` TINYINT,
  `tires_condition` TINYINT,
  `lights_condition` TINYINT,
  `engine_condition` TINYINT,
  `notes` VARCHAR(100),
  `vehicle_id` INT NOT NULL,
  PRIMARY KEY (`checklist_id`),
  FOREIGN KEY (`vehicle_id`) REFERENCES `vehicles`(`vehicle_id`),
  FOREIGN KEY (`rental_id`) REFERENCES `rentals`(`rental_id`),
  FOREIGN KEY (`inspection_type_id`) REFERENCES `inspection_types`(`inspection_type_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `maintenance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `maintenance` (
  `maintenance_id` INT NOT NULL AUTO_INCREMENT,
  `vehicle_id` INT NOT NULL,
  `maintenance_type` VARCHAR(100) NOT NULL,
  `start_date` DATE NOT NULL,
  `end_date` DATE,
  `cost` DECIMAL(10,2),
  `description` TEXT,
  `service_provider` VARCHAR(100),
  `maintenance_status_id` INT NOT NULL,
  PRIMARY KEY (`maintenance_id`),
  FOREIGN KEY (`vehicle_id`) REFERENCES `vehicles`(`vehicle_id`),
  FOREIGN KEY (`maintenance_status_id`) REFERENCES `maintenance_status`(`maintenance_status_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `user` (
  `user_id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(50) NOT NULL UNIQUE,
  `password_hash` TEXT NOT NULL,
  `role_id` INT NOT NULL,
  PRIMARY KEY (`user_id`),
  FOREIGN KEY (`role_id`) REFERENCES `user_roles`(`role_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `terms_and_policies`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `terms_and_policies` (
  `terms_id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(255) NOT NULL,
  `content` TEXT NOT NULL,
  `version` VARCHAR(10) NOT NULL,
  `effective_date` DATE NOT NULL,
  PRIMARY KEY (`terms_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `sales_report`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sales_report` (
  `report_id` INT NOT NULL AUTO_INCREMENT,
  `report_date` DATE NOT NULL,
  `total_earnings` DECIMAL(12,2) NOT NULL,
  `total_rentals` INT DEFAULT 0,
  `total_penalties` DECIMAL(12,2) DEFAULT 0,
  `generated_by` INT NOT NULL,
  PRIMARY KEY (`report_id`),
  FOREIGN KEY (`generated_by`) REFERENCES `user`(`user_id`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Insert lookup table data
-- -----------------------------------------------------
INSERT INTO `transmission_types` (`transmission_type`) VALUES
('manual'),
('automatic'),
('cvt');

INSERT INTO `fuel_types` (`fuel_type`) VALUES
('gasoline'),
('diesel'),
('electric'),
('hybrid');

INSERT INTO `vehicle_status` (`status_name`) VALUES
('available'),
('rented'),
('reserved'),
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

INSERT INTO `reservation_status` (`status_name`) VALUES
('pending'),
('confirmed'),
('cancelled');

INSERT INTO `maintenance_status` (`status_name`) VALUES
('scheduled'),
('in_progress'),
('completed');

INSERT INTO `user_roles` (`role_name`) VALUES
('admin'),
('staff');

INSERT INTO `inspection_types` (`inspection_type_name`) VALUES
('before_rent'),
('after_rent');

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;