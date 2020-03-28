-- MySQL Workbench Synchronization
-- Generated: 2020-03-28 12:56
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: asus

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `TableProjet` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Createur` (
  `idCreateur` INT(11) GENERATED ALWAYS AS (Id) VIRTUAL,
  `Nom` VARCHAR(45) NULL DEFAULT '\"Chef Jason\"',
  `idClient` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idCreateur`),
  UNIQUE INDEX `idCreateur_UNIQUE` (`idCreateur` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Recette` (
  `idRecette` INT(11) NOT NULL AUTO_INCREMENT,
  `quantite` INT(11) NULL DEFAULT 0,
  `descriptif` VARCHAR(150) NULL DEFAULT '\"C\'est très bon\"',
  `prix` FLOAT(11) NULL DEFAULT NULL,
  `listingredient` VARCHAR(45) NULL DEFAULT NULL,
  `idCreateur` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idRecette`),
  INDEX `idCreateur_idx` (`idCreateur` ASC) VISIBLE,
  CONSTRAINT `idCreateur`
    FOREIGN KEY (`idCreateur`)
    REFERENCES `TableProjet`.`Createur` (`idCreateur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Ingredient` (
  `idIngredient` INT(11) NOT NULL AUTO_INCREMENT,
  `categorie` VARCHAR(45) NULL DEFAULT NULL,
  `prixUnité` FLOAT(11) NULL DEFAULT NULL,
  `stockMini` INT(11) NULL DEFAULT NULL,
  `stockActuel` INT(11) NULL DEFAULT NULL,
  `stockMax` INT(11) NULL DEFAULT NULL,
  `idFournisseur` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idIngredient`),
  INDEX `idFournisseur_idx` (`idFournisseur` ASC) VISIBLE,
  CONSTRAINT `idFournisseur`
    FOREIGN KEY (`idFournisseur`)
    REFERENCES `TableProjet`.`Fournisseur` (`idFournisseur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Fournisseur` (
  `idFournisseur` INT(11) NOT NULL AUTO_INCREMENT,
  `telephone` INT(10) NULL DEFAULT 0000000000,
  PRIMARY KEY (`idFournisseur`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`IdentifiantMotDepasse` (
  `idClient` INT(11) NOT NULL,
  `motDePasse` VARCHAR(45) NULL DEFAULT NULL,
  `Identifiant` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idClient`),
  UNIQUE INDEX `Identifiant_UNIQUE` (`Identifiant` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

INSERT INTO `tableprojet`.`client` (`idClient`,`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`) VALUES (1,'Claude','Jean','rue de la paie','bourg','1957-11-24',0674586954,'jean.claude@orange.fr',0,0);
INSERT INTO `tableprojet`.`client` (`idClient`,`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`) VALUES (2,'Morin','Loic','rue du tarpin','marseille','1999-04-18',0685314692,'morin.loic@gmail.fr',0,10000);
INSERT INTO `tableprojet`.`client` (`idClient`,`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`) VALUES (3,'Meynet','Florian','rue de la boulangerie','perrognier','1998-02-17',067458365,'meynet.florian@orange.fr',0,10000);
