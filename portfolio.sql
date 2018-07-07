-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema portfolio
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `portfolio` DEFAULT CHARACTER SET utf8 ;
USE `portfolio` ;

-- -----------------------------------------------------
-- Table `portfolio`.`atividade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `portfolio`.`atividade` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `portfolio`.`criterio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `portfolio`.`criterio` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `portfolio`.`portfolio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `portfolio`.`portfolio` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(45) NOT NULL,
  `dataCriacao` DATETIME NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `portfolio`.`portfolio_atividade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `portfolio`.`portfolio_atividade` (
  `atividade_id` INT(11) NOT NULL,
  `portfolio_id` INT(11) NOT NULL,
  INDEX `fk_atividade_has_portifolio_portifolio1_idx` (`portfolio_id` ASC),
  INDEX `fk_atividade_has_portifolio_atividade1_idx` (`atividade_id` ASC),
  CONSTRAINT `fk_atividade_has_portifolio_atividade1`
    FOREIGN KEY (`atividade_id`)
    REFERENCES `portfolio`.`atividade` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_atividade_has_portifolio_portifolio1`
    FOREIGN KEY (`portfolio_id`)
    REFERENCES `portfolio`.`portfolio` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `portfolio`.`portfolio_criterio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `portfolio`.`portfolio_criterio` (
  `criterio_id` INT(11) NOT NULL,
  `portfolio_id` INT(11) NOT NULL,
  INDEX `fk_criterio_has_portifolio_portifolio1_idx` (`portfolio_id` ASC),
  INDEX `fk_criterio_has_portifolio_criterio1_idx` (`criterio_id` ASC),
  CONSTRAINT `fk_criterio_has_portifolio_criterio1`
    FOREIGN KEY (`criterio_id`)
    REFERENCES `portfolio`.`criterio` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_criterio_has_portifolio_portifolio1`
    FOREIGN KEY (`portfolio_id`)
    REFERENCES `portfolio`.`portfolio` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `portfolio`.`rel_atividade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `portfolio`.`rel_atividade` (
  `atividade_id1` INT(11) NOT NULL,
  `atividade_id2` INT(11) NOT NULL,
  `criterio_id` INT(11) NOT NULL,
  `nota` DOUBLE NULL DEFAULT NULL,
  `portfolio_id` INT(11) NOT NULL,
  INDEX `fk_rel_atividade_atividade2_idx` (`atividade_id2` ASC),
  INDEX `fk_rel_atividade_criterio1_idx` (`criterio_id` ASC),
  INDEX `fk_rel_atividade_portfolio1_idx` (`portfolio_id` ASC),
  CONSTRAINT `fk_rel_atividade_atividade1`
    FOREIGN KEY (`atividade_id1`)
    REFERENCES `portfolio`.`atividade` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_rel_atividade_atividade2`
    FOREIGN KEY (`atividade_id2`)
    REFERENCES `portfolio`.`atividade` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_rel_atividade_criterio1`
    FOREIGN KEY (`criterio_id`)
    REFERENCES `portfolio`.`criterio` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_rel_atividade_portfolio1`
    FOREIGN KEY (`portfolio_id`)
    REFERENCES `portfolio`.`portfolio` (`id`)
    ON DELETE CASCADE
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `portfolio`.`rel_criterio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `portfolio`.`rel_criterio` (
  `criterio_id1` INT(11) NOT NULL,
  `criterio_id2` INT(11) NOT NULL,
  `nota` DOUBLE NULL DEFAULT NULL,
  `portfolio_id` INT(11) NOT NULL,
  INDEX `fk_rel_criterio_criterio1_idx` (`criterio_id2` ASC),
  INDEX `fk_rel_criterio_portfolio1_idx` (`portfolio_id` ASC),
  CONSTRAINT `fk_rel_criterio_criterio`
    FOREIGN KEY (`criterio_id1`)
    REFERENCES `portfolio`.`criterio` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_rel_criterio_criterio1`
    FOREIGN KEY (`criterio_id2`)
    REFERENCES `portfolio`.`criterio` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_rel_criterio_portfolio1`
    FOREIGN KEY (`portfolio_id`)
    REFERENCES `portfolio`.`portfolio` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
