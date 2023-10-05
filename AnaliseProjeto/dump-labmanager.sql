-- MySQL Workbench Synchronization
-- Generated: 2023-10-05 11:08
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: marco

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `LabManager` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `LabManager`.`Instituicao` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cnpj` VARCHAR(14) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `cep` VARCHAR(8) NULL DEFAULT NULL,
  `rua` VARCHAR(50) NULL DEFAULT NULL,
  `bairro` VARCHAR(50) NULL DEFAULT NULL,
  `numero` VARCHAR(15) NULL DEFAULT NULL,
  `cidade` VARCHAR(50) NULL DEFAULT NULL,
  `estado` VARCHAR(2) NULL DEFAULT NULL,
  `ativo` TINYINT(4) NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `cnpj_UNIQUE` (`cnpj` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `LabManager`.`Pessoa` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `cpf` VARCHAR(11) NOT NULL,
  `nome` VARCHAR(50) NULL DEFAULT NULL,
  `cep` VARCHAR(8) NULL DEFAULT NULL,
  `rua` VARCHAR(50) NULL DEFAULT NULL,
  `bairro` VARCHAR(50) NULL DEFAULT NULL,
  `numero` VARCHAR(15) NULL DEFAULT NULL,
  `cidade` VARCHAR(50) NULL DEFAULT NULL,
  `estado` VARCHAR(2) NULL DEFAULT NULL,
  `ativo` TINYINT(4) NOT NULL DEFAULT 1,
  `idInstituicao` INT(10) UNSIGNED NOT NULL,
  `idSetor` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `cpd_UNIQUE` (`cpf` ASC),
  INDEX `fk_Pessoa_Instituicao_idx` (`idInstituicao` ASC),
  INDEX `fk_Pessoa_Setor1_idx` (`idSetor` ASC),
  CONSTRAINT `fk_Pessoa_Instituicao`
    FOREIGN KEY (`idInstituicao`)
    REFERENCES `LabManager`.`Instituicao` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_Pessoa_Setor1`
    FOREIGN KEY (`idSetor`)
    REFERENCES `LabManager`.`Setor` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `LabManager`.`Setor` (
  `id` INT(11) NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `LabManager`.`Sala` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `localizacao` VARCHAR(50) NULL DEFAULT NULL,
  `idSetor` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Sala_Setor1_idx` (`idSetor` ASC),
  CONSTRAINT `fk_Sala_Setor1`
    FOREIGN KEY (`idSetor`)
    REFERENCES `LabManager`.`Setor` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `LabManager`.`Software` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `versao` VARCHAR(50) NOT NULL,
  `key` VARCHAR(100) NULL DEFAULT NULL,
  `idSetor` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `key_UNIQUE` (`key` ASC),
  INDEX `fk_Software_Setor1_idx` (`idSetor` ASC),
  CONSTRAINT `fk_Software_Setor1`
    FOREIGN KEY (`idSetor`)
    REFERENCES `LabManager`.`Setor` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `LabManager`.`SoftwareSala` (
  `idSoftware` INT(10) UNSIGNED NOT NULL,
  `idSala` INT(11) NOT NULL,
  `dataAtualizacao` DATETIME NOT NULL,
  `solicitante` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`idSoftware`, `idSala`),
  INDEX `fk_SoftwareSala_Sala1_idx` (`idSala` ASC),
  INDEX `fk_SoftwareSala_Software1_idx` (`idSoftware` ASC),
  CONSTRAINT `fk_SoftwareSala_Software1`
    FOREIGN KEY (`idSoftware`)
    REFERENCES `LabManager`.`Software` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_SoftwareSala_Sala1`
    FOREIGN KEY (`idSala`)
    REFERENCES `LabManager`.`Sala` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `LabManager`.`Equipamento` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `idSala` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Equipamento_Sala1_idx` (`idSala` ASC),
  CONSTRAINT `fk_Equipamento_Sala1`
    FOREIGN KEY (`idSala`)
    REFERENCES `LabManager`.`Sala` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `LabManager`.`SoftwareEquipamento` (
  `idSoftware` INT(10) UNSIGNED NOT NULL,
  `idEquipamento` INT(10) UNSIGNED NOT NULL,
  `dataAtualizacao` DATETIME NOT NULL,
  PRIMARY KEY (`idSoftware`, `idEquipamento`),
  INDEX `fk_SoftwareEquipamento_Equipamento1_idx` (`idEquipamento` ASC),
  INDEX `fk_SoftwareEquipamento_Software1_idx` (`idSoftware` ASC),
  CONSTRAINT `fk_SoftwareEquipamento_Software1`
    FOREIGN KEY (`idSoftware`)
    REFERENCES `LabManager`.`Software` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_SoftwareEquipamento_Equipamento1`
    FOREIGN KEY (`idEquipamento`)
    REFERENCES `LabManager`.`Equipamento` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `LabManager`.`AtividadeEquipamento` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `data` DATETIME NOT NULL,
  `idEquipamento` INT(10) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_AtividadeEquipamento_Equipamento1_idx` (`idEquipamento` ASC),
  CONSTRAINT `fk_AtividadeEquipamento_Equipamento1`
    FOREIGN KEY (`idEquipamento`)
    REFERENCES `LabManager`.`Equipamento` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
