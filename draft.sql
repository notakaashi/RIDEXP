-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`car_category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`car_category` (
  `car_category_id` INT NOT NULL AUTO_INCREMENT,
  `category_name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NOT NULL,
  `transmission` VARCHAR(45) NULL,
  PRIMARY KEY (`car_category_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`cars`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`cars` (
  `status` VARCHAR(45) NULL,
  `car_id` INT NOT NULL AUTO_INCREMENT,
  `status` ENUM('available', 'under maintenance', 'booked') NOT NULL,
  `car_cateogry_id` INT NOT NULL,
  `make` VARCHAR(45) NOT NULL,
  `model_name` VARCHAR(45) NOT NULL,
  `year` INT NOT NULL,
  `license_plate` VARCHAR(45) NOT NULL,
  `status` ENUM('available', 'rented', 'reserved', 'under_maintenance', 'out_of_service', 'cleaning', ' damaged') NULL,
  `carscol` VARCHAR(45) NULL,
  PRIMARY KEY (`car_id`),
  UNIQUE INDEX `car_id_UNIQUE` (`car_id` ASC) VISIBLE,
  INDEX `fk_cars_car_category_idx` (`car_cateogry_id` ASC) VISIBLE,
  CONSTRAINT `fk_cars_car_category`
    FOREIGN KEY (`car_cateogry_id`)
    REFERENCES `mydb`.`car_category` (`car_category_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`motor_category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`motor_category` (
  `motor_category_id` INT NOT NULL AUTO_INCREMENT,
  `category_name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NOT NULL,
  `transmission` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`motor_category_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`motors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`motors` (
  `motor_id` INT NOT NULL,
  `motor_category_id` INT NOT NULL,
  `make` VARCHAR(45) NOT NULL,
  `model` VARCHAR(45) NULL,
  `year` VARCHAR(45) NULL,
  `license_plate` VARCHAR(45) NULL,
  `status` ENUM('available', 'rented', 'reserved', 'under_maintenance', 'out_of_service', 'cleaning', 'damaged') NULL,
  PRIMARY KEY (`motor_id`),
  INDEX `fk_motors_motor_category1_idx` (`motor_category_id` ASC) VISIBLE,
  CONSTRAINT `fk_motors_motor_category1`
    FOREIGN KEY (`motor_category_id`)
    REFERENCES `mydb`.`motor_category` (`motor_category_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`vehicles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`vehicles` (
  `vehicle_id` INT NOT NULL AUTO_INCREMENT,
  `vehicle_type` ENUM('car', 'motor') NOT NULL,
  `item_id` INT NOT NULL,
  PRIMARY KEY (`vehicle_id`),
  UNIQUE INDEX `vehicle_type_UNIQUE` (`vehicle_type` ASC) VISIBLE,
  UNIQUE INDEX `item_id_UNIQUE` (`item_id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`checklist`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`checklist` (
  `checklist_id` INT NOT NULL,
  `inspection_date` DATE NOT NULL,
  `inspection_type` ENUM('before_rent', 'after_rent') NOT NULL,
  `windows_condition` TINYINT NULL,
  `tires_condition` TINYINT NULL,
  `lights_condition` TINYINT NULL,
  `engine_condition` TINYINT NULL,
  `checklistcol` TINYINT NOT NULL,
  `notes` VARCHAR(45) NULL,
  `vehicle_id` INT NOT NULL,
  PRIMARY KEY (`checklist_id`),
  INDEX `fk_checklist_vehicles1_idx` (`vehicle_id` ASC) VISIBLE,
  CONSTRAINT `fk_checklist_vehicles1`
    FOREIGN KEY (`vehicle_id`)
    REFERENCES `mydb`.`vehicles` (`vehicle_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`customers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`customers` (
  `customer_id` INT NOT NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `date_of_birth` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `phone` VARCHAR(45) NULL,
  `address` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`customer_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`rental_rate`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`rental_rate` (
  `rate_id` INT NOT NULL,
  `rate_per_hour` VARCHAR(45) NULL,
  `vehicle_id` INT NOT NULL,
  PRIMARY KEY (`rate_id`),
  INDEX `fk_rental_rate_vehicles1_idx` (`vehicle_id` ASC) VISIBLE,
  CONSTRAINT `fk_rental_rate_vehicles1`
    FOREIGN KEY (`vehicle_id`)
    REFERENCES `mydb`.`vehicles` (`vehicle_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`rentals`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`rentals` (
  `rental_id` INT NOT NULL,
  `start_date` DATETIME NULL,
  `end_date` DATETIME NULL,
  `customer_id` INT NOT NULL,
  `vehicle_id` INT NOT NULL,
  `status` ENUM('active', 'completed', 'cancelled') NULL,
  PRIMARY KEY (`rental_id`),
  INDEX `fk_rentals_customers1_idx` (`customer_id` ASC) VISIBLE,
  INDEX `fk_rentals_vehicles1_idx` (`vehicle_id` ASC) VISIBLE,
  CONSTRAINT `fk_rentals_customers1`
    FOREIGN KEY (`customer_id`)
    REFERENCES `mydb`.`customers` (`customer_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rentals_vehicles1`
    FOREIGN KEY (`vehicle_id`)
    REFERENCES `mydb`.`vehicles` (`vehicle_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
