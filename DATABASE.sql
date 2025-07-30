-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema ridexp
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ridexp
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ridexp` DEFAULT CHARACTER SET utf8 ;
USE `ridexp` ;

-- -----------------------------------------------------
-- Table `ridexp`.`transmission_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`transmission_types` (
  `transmission_id` INT(11) NOT NULL AUTO_INCREMENT,
  `transmission_type` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`transmission_id`)  )
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`fuel_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`fuel_types` (
  `fuel_id` INT(11) NOT NULL AUTO_INCREMENT,
  `fuel_type` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`fuel_id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`car_category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`car_category` (
  `car_category_id` INT(11) NOT NULL AUTO_INCREMENT,
  `category_name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(100) NOT NULL,
  `transmission_id` INT(11) NULL DEFAULT NULL,
  `fuel_id` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`car_category_id`),
  INDEX (`transmission_id`) ,
  INDEX (`fuel_id`)  ,
  CONSTRAINT `car_category_ibfk_1`
    FOREIGN KEY (`transmission_id`)
    REFERENCES `ridexp`.`transmission_types` (`transmission_id`),
  CONSTRAINT `car_category_ibfk_2`
    FOREIGN KEY (`fuel_id`)
    REFERENCES `ridexp`.`fuel_types` (`fuel_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`vehicle_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`vehicle_status` (
  `status_id` INT(11) NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`status_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`cars`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`cars` (
  `car_id` INT(11) NOT NULL AUTO_INCREMENT,
  `car_category_id` INT(11) NOT NULL,
  `make` VARCHAR(45) NOT NULL,
  `model_name` VARCHAR(45) NOT NULL,
  `year` INT(11) NOT NULL,
  `license_plate` VARCHAR(45) NOT NULL,
  `color` VARCHAR(30) NULL DEFAULT NULL,
  `seating_capacity` INT(11) NULL DEFAULT NULL,
  `mileage` INT(11) NULL DEFAULT 0,
  PRIMARY KEY (`car_id`),
  UNIQUE INDEX (`license_plate`),
  INDEX (`car_category_id`),
  CONSTRAINT `cars_ibfk_1`
    FOREIGN KEY (`car_category_id`)
    REFERENCES `ridexp`.`car_category` (`car_category_id`)
) ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`vehicles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`vehicles` (
  `vehicle_id` INT(11) NOT NULL AUTO_INCREMENT,
  `vehicle_type` ENUM('car', 'motor') NOT NULL,
  `item_id` INT(11) NOT NULL,
  `status_id` INT(11) NOT NULL,
  PRIMARY KEY (`vehicle_id`),
  INDEX (`status_id`),
  CONSTRAINT `vehicles_ibfk_1`
    FOREIGN KEY (`status_id`)
    REFERENCES `ridexp`.`vehicle_status` (`status_id`)
) ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


CREATE TABLE IF NOT EXISTS `ridexp`.`customers` (
  `customer_id` INT(11) NOT NULL AUTO_INCREMENT,
  `user_id` INT(11) NOT NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `date_of_birth` DATE NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `phone` VARCHAR(20) NULL DEFAULT NULL,
  `address` VARCHAR(255) NOT NULL,
  `license_number` VARCHAR(50) NULL DEFAULT NULL,
  `license_expiry` DATE NULL DEFAULT NULL,
  `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`customer_id`),
  CONSTRAINT `fk_customers_user`
    FOREIGN KEY (`user_id`) REFERENCES `user`(`user_id`)
    ON DELETE CASCADE
)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`rental_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`rental_status` (
  `rental_status_id` INT(11) NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`rental_status_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`rentals`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`rentals` (
  `rental_id` INT(11) NOT NULL AUTO_INCREMENT,
  `rental_duration_days` INT DEFAULT 1,
  `pickup_date` DATE NOT NULL,
  `pickup_time` VARCHAR(50) NOT NULL,
  `return_date` DATE NULL DEFAULT NULL,
  `return_time` VARCHAR(50) NULL DEFAULT NULL,
  `customer_id` INT(11) NOT NULL,
  `vehicle_id` INT(11) NOT NULL,
  `amount` DECIMAL(10,2) NULL DEFAULT NULL,
  `rental_status_id` INT(11) NOT NULL,
  `pickup_place` VARCHAR(255) NOT NULL DEFAULT 'RDXP Ave, Taguig City',
  `return_place` VARCHAR(255) NOT NULL DEFAULT 'RDXP Ave, Taguig City',
  PRIMARY KEY (`rental_id`),
  INDEX (`customer_id`),
  INDEX (`vehicle_id`),
  INDEX (`rental_status_id`),
  CONSTRAINT `rentals_ibfk_1`
    FOREIGN KEY (`customer_id`)
    REFERENCES `ridexp`.`customers` (`customer_id`),
  CONSTRAINT `rentals_ibfk_2`
    FOREIGN KEY (`vehicle_id`)
    REFERENCES `ridexp`.`vehicles` (`vehicle_id`),
  CONSTRAINT `rentals_ibfk_3`
    FOREIGN KEY (`rental_status_id`)
    REFERENCES `ridexp`.`rental_status` (`rental_status_id`)
) ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

-- -----------------------------------------------------
-- Table `ridexp`.`inspection_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`inspection_types` (
  `inspection_type_id` INT(11) NOT NULL AUTO_INCREMENT,
  `inspection_type_name` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`inspection_type_id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`checklist`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`checklist` (
  `checklist_id` INT(11) NOT NULL AUTO_INCREMENT,
  `rental_id` INT(11) NOT NULL,
  `inspection_date` DATE NOT NULL,
  `inspection_type_id` INT(11) NOT NULL,
  `windows_condition` TINYINT(4) NULL DEFAULT NULL,
  `tires_condition` TINYINT(4) NULL DEFAULT NULL,
  `lights_condition` TINYINT(4) NULL DEFAULT NULL,
  `engine_condition` TINYINT(4) NULL DEFAULT NULL,
  `notes` VARCHAR(100) NULL DEFAULT NULL,
  `vehicle_id` INT(11) NOT NULL,
  PRIMARY KEY (`checklist_id`),
  INDEX( `vehicle_id`),
  INDEX( `rental_id` ) ,
  INDEX (`inspection_type_id`)  ,
  CONSTRAINT `checklist_ibfk_1`
    FOREIGN KEY (`vehicle_id`)
    REFERENCES `ridexp`.`vehicles` (`vehicle_id`),
  CONSTRAINT `checklist_ibfk_2`
    FOREIGN KEY (`rental_id`)
    REFERENCES `ridexp`.`rentals` (`rental_id`),
  CONSTRAINT `checklist_ibfk_3`
    FOREIGN KEY (`inspection_type_id`)
    REFERENCES `ridexp`.`inspection_types` (`inspection_type_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`maintenance_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`maintenance_status` (
  `maintenance_status_id` INT(11) NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL,
  `start_date` DATE DEFAULT (CURRENT_DATE),
  PRIMARY KEY (`maintenance_status_id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`maintenance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`maintenance` (
  `maintenance_id` INT(11) NOT NULL AUTO_INCREMENT,
  `vehicle_id` INT(11) NOT NULL,
  `maintenance_type` VARCHAR(100) NOT NULL,
  `start_date` DATE NOT NULL,
  `end_date` DATE NULL DEFAULT NULL,
  `cost` DECIMAL(10,2) NULL DEFAULT NULL,
  `description` TEXT NULL DEFAULT NULL,
  `service_provider` VARCHAR(100) NULL DEFAULT NULL,
  `maintenance_status_id` INT(11) NOT NULL,
  PRIMARY KEY (`maintenance_id`),
  INDEX (`vehicle_id` ) ,
  INDEX (`maintenance_status_id`)  ,
  CONSTRAINT `maintenance_ibfk_1`
    FOREIGN KEY (`vehicle_id`)
    REFERENCES `ridexp`.`vehicles` (`vehicle_id`),
  CONSTRAINT `maintenance_ibfk_2`
    FOREIGN KEY (`maintenance_status_id`)
    REFERENCES `ridexp`.`maintenance_status` (`maintenance_status_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`motor_category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`motor_category` (
  `motor_category_id` INT(11) NOT NULL AUTO_INCREMENT,
  `category_name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(100) NOT NULL,
  `transmission_id` INT(11) NOT NULL,
  `fuel_id` INT(11) NULL DEFAULT NULL,
  `engine_capacity` VARCHAR(20) NULL DEFAULT NULL,
  PRIMARY KEY (`motor_category_id`),
  INDEX (`transmission_id`)  ,
  INDEX (`fuel_id`) ,
  CONSTRAINT `motor_category_ibfk_1`
    FOREIGN KEY (`transmission_id`)
    REFERENCES `ridexp`.`transmission_types` (`transmission_id`),
  CONSTRAINT `motor_category_ibfk_2`
    FOREIGN KEY (`fuel_id`)
    REFERENCES `ridexp`.`fuel_types` (`fuel_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`motors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`motors` (
  `motor_id` INT(11) NOT NULL AUTO_INCREMENT,
  `motor_category_id` INT(11) NOT NULL,
  `make` VARCHAR(45) NOT NULL,
  `model` VARCHAR(45) NULL DEFAULT NULL,
  `year` INT(11) NOT NULL,
  `license_plate` VARCHAR(45) NOT NULL,
  `color` VARCHAR(30) NULL DEFAULT NULL,
  `mileage` INT(11) NULL DEFAULT 0,
  PRIMARY KEY (`motor_id`),
  UNIQUE INDEX (`license_plate`),
  INDEX (`motor_category_id`),
  CONSTRAINT `motors_ibfk_1`
    FOREIGN KEY (`motor_category_id`)
    REFERENCES `ridexp`.`motor_category` (`motor_category_id`)
) ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`payment_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`payment_status` (
  `payment_status_id` INT(11) NOT NULL AUTO_INCREMENT,
  `status_name` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`payment_status_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`payment_methods`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`payment_methods` (
  `method_id` INT(11) NOT NULL AUTO_INCREMENT,
  `method_name` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`method_id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`payment` (
  `payment_id` INT(11) NOT NULL AUTO_INCREMENT,
  `rental_id` INT(11) NOT NULL,
  `amount` DECIMAL(10,2) NOT NULL,
  `payment_status_id` INT(11) NOT NULL,
  `method_id` INT(11) NOT NULL,
  `paid_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
  PRIMARY KEY (`payment_id`),
  INDEX (`rental_id` ) ,
  INDEX( `payment_status_id`)  ,
  INDEX (`method_id` ) ,
  CONSTRAINT `payment_ibfk_1`
    FOREIGN KEY (`rental_id`)
    REFERENCES `ridexp`.`rentals` (`rental_id`),
  CONSTRAINT `payment_ibfk_2`
    FOREIGN KEY (`payment_status_id`)
    REFERENCES `ridexp`.`payment_status` (`payment_status_id`),
  CONSTRAINT `payment_ibfk_3`
    FOREIGN KEY (`method_id`)
    REFERENCES `ridexp`.`payment_methods` (`method_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`penalty`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`penalty` (
  `penalty_id` INT(11) NOT NULL AUTO_INCREMENT,
  `rental_id` INT(11) NOT NULL,
  `description` TEXT NOT NULL,
  `amount` DECIMAL(10,2) NOT NULL,
  `is_paid` TINYINT(1) NULL DEFAULT 0,
  PRIMARY KEY (`penalty_id`),
  INDEX (`rental_id` ) ,
  CONSTRAINT `penalty_ibfk_1`
    FOREIGN KEY (`rental_id`)
    REFERENCES `ridexp`.`rentals` (`rental_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`rental_rate`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`rental_rate` (
  `rate_id` INT(11) NOT NULL AUTO_INCREMENT,
  `vehicle_id` INT(11) NOT NULL,
  `rate_per_day` DECIMAL(10,2) NULL DEFAULT NULL,
  `effective_date` DATE NOT NULL,
  PRIMARY KEY (`rate_id`),
  INDEX (`vehicle_id`),
  CONSTRAINT `rental_rate_ibfk_1`
    FOREIGN KEY (`vehicle_id`)
    REFERENCES `ridexp`.`vehicles` (`vehicle_id`)
) ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`user_roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`user_roles` (
  `role_id` INT(11) NOT NULL AUTO_INCREMENT,
  `role_name` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`role_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ridexp`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `user` (
    `user_id` INT(11) NOT NULL AUTO_INCREMENT,
    `username` VARCHAR(50) NOT NULL UNIQUE,
    `password_hash` VARCHAR(64) NOT NULL,
    `role_id` INT(11) NOT NULL,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (`user_id`),
    INDEX (`role_id`),
    CONSTRAINT `user_ibk_1`
        FOREIGN KEY (`role_id`) REFERENCES `ridexp`.`user_roles` (`role_id`)
        ON DELETE CASCADE
) ENGINE = InnoDB DEFAULT CHARSET = utf8;



-- -----------------------------------------------------
-- Table `ridexp`.`sales_report`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`sales_report` (
  `report_id` INT(11) NOT NULL AUTO_INCREMENT,
  `report_date` DATE NOT NULL DEFAULT (CURDATE()),
  `earnings` DECIMAL(12,2) NULL DEFAULT NULL,
  `rental_id` INT(11) NOT NULL,
  `penalties` DECIMAL(12,2) NULL DEFAULT NULL,
  `generated_by` INT(11) NOT NULL,
  PRIMARY KEY (`report_id`),
  INDEX (`rental_id`),
  INDEX (`generated_by`),
  CONSTRAINT `sales_report_ibfk_1`
    FOREIGN KEY (`generated_by`)
    REFERENCES `ridexp`.`user` (`user_id`),
  CONSTRAINT `sales_report_ibfk_2`
    FOREIGN KEY (`rental_id`)
    REFERENCES `ridexp`.`rentals` (`rental_id`)
) ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8;



-- -----------------------------------------------------
-- Table `ridexp`.`terms_and_policies`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ridexp`.`terms_and_policies` (
  `terms_id` INT(11) NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(255) NOT NULL,
  `content` TEXT NOT NULL,
  `version` VARCHAR(10) NOT NULL,
  `effective_date` DATE NOT NULL,
  PRIMARY KEY (`terms_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS cars_pic (
    pic_id INT AUTO_INCREMENT PRIMARY KEY,
    car_id INT NOT NULL,
    image VARCHAR(100) NOT NULL,
    FOREIGN KEY (car_id) REFERENCES cars(car_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS motors_pic (
    pic_id INT AUTO_INCREMENT PRIMARY KEY,
    motor_id INT NOT NULL,
    image VARCHAR(100) NOT NULL,
    FOREIGN KEY (motor_id) REFERENCES motors(motor_id)
);


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


DELIMITER $$
CREATE TRIGGER rental_return_date_calculator
BEFORE INSERT ON rentals
FOR EACH ROW
BEGIN
    -- Calculate rental duration in days based on the difference between return and pickup dates
    SET NEW.rental_duration_days = DATEDIFF(NEW.return_date, NEW.pickup_date);
    
    -- Ensure minimum 1 day rental (in case of same-day returns)
    IF NEW.rental_duration_days < 1 THEN
        SET NEW.rental_duration_days = 1;
    END IF;
END$$
DELIMITER ;
