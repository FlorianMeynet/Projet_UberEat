-- MySQL Workbench Synchronization
-- Generated: 2020-03-29 19:09
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: asus

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `TableProjet` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Createur` (
  `idCreateur` INT(11) NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(45) NULL DEFAULT '\"Chef Jason\"',
  `idClient` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idCreateur`),
  INDEX `idClient_idx` (`idClient` ASC) VISIBLE,
  UNIQUE INDEX `idCreateur_UNIQUE` (`idCreateur` ASC) VISIBLE,
  CONSTRAINT `idClient`
    FOREIGN KEY (`idClient`)
    REFERENCES `TableProjet`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Recette` (
  `idRecette` INT(11) NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(20) NULL DEFAULT NULL,
  `descriptif` VARCHAR(150) NULL DEFAULT '\"C\'est très bon\"',
  `prix` FLOAT(11) NOT NULL,
  `listingredient` VARCHAR(45) NOT NULL,
  `idCreateur` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idRecette`),
  INDEX `idCreateur_idx` (`idCreateur` ASC) VISIBLE,
  UNIQUE INDEX `idRecette_UNIQUE` (`idRecette` ASC) VISIBLE,
  CONSTRAINT `idCreateur`
    FOREIGN KEY (`idCreateur`)
    REFERENCES `TableProjet`.`Createur` (`idCreateur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Client` (
  `idClient` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  `prenom` VARCHAR(15) NOT NULL,
  `adresse` VARCHAR(45) NOT NULL,
  `ville` VARCHAR(45) NOT NULL,
  `date_naissance` DATE NOT NULL,
  `numeroDeTelephone` INT(10) NOT NULL DEFAULT 0606060606,
  `adresseEmail` VARCHAR(45) NOT NULL,
  `estCreateur` TINYINT(4) NULL DEFAULT 0,
  `capitalCooks` INT(11) NULL DEFAULT 0,
  `motDutiePasse` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idClient`),
  UNIQUE INDEX `idClient_UNIQUE` (`idClient` ASC) VISIBLE,
  UNIQUE INDEX `adresseEmail_UNIQUE` (`adresseEmail` ASC) VISIBLE,
  UNIQUE INDEX `numeroDeTelephone_UNIQUE` (`numeroDeTelephone` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Ingredient` (
  `idIngredient` INT(11) NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(20) NULL DEFAULT NULL,
  `idFournisseur` INT(11) NULL DEFAULT NULL,
  `categorie` VARCHAR(45) NOT NULL,
  `prixUnité` FLOAT(11) NOT NULL DEFAULT 0,
  `stockMini` INT(11) NULL DEFAULT NULL,
  `stockActuel` INT(11) NULL DEFAULT NULL,
  `stockMax` INT(11) NOT NULL,
  PRIMARY KEY (`idIngredient`),
  INDEX `idFournisseur_idx` (`idFournisseur` ASC) VISIBLE,
  UNIQUE INDEX `idIngredient_UNIQUE` (`idIngredient` ASC) VISIBLE,
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
  `Nom` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idFournisseur`),
  UNIQUE INDEX `idFournisseur_UNIQUE` (`idFournisseur` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Claude','Jean','rue de la paie','bourg','1957-11-24',0674586954,'jean.claude@orange.fr',0,0,'1234');
INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Morin','Loic','rue du tarpin','marseille','1999-04-18',0685314692,'morin.loic@gmail.fr',0,10000,'caca');
INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Meynet','Florian','rue de la boulangerie','perrognier','1998-02-17',067458365,'meynet.florian@orange.fr',0,10000,'mdpfacile');
INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Admin','Admin','ESILV','PARIS','0000-00-00',0000,'admin',1,1000000,'mdpfacile');

INSERT INTO `tableprojet`.`createur` (`Nom`,`idClient`) VALUES ('Le cuisto de marseille',2);
INSERT INTO `tableprojet`.`createur` (`Nom`,`idClient`) VALUES ('Le cuisto de haute savoie',3);

INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0682197635,'France boisson');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0785314587,'Les produits laitiers');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0647365218,'Carrefour');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0725361426,'Intermarché');

INSERT INTO `tableprojet`.`ingredient` (`idFournisseur`,`nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (1,'Biere','boisson',2,10,50,200);
INSERT INTO `tableprojet`.`ingredient` (`idFournisseur`,`nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (3,'Thai','riz',2.74,2,10,20);
INSERT INTO `tableprojet`.`ingredient` (`idFournisseur`,`nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (3,'Long','riz',1.99,2,10,20);
INSERT INTO `tableprojet`.`ingredient` (`idFournisseur`,`nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (4,'Spaghetti','pate',3,2,10,20);
INSERT INTO `tableprojet`.`ingredient` (`idFournisseur`,`Nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (4,'Carotte','legume',1.14,2,5,10);

INSERT INTO `tableprojet`.`recette` (`Nom`,`descriptif`,`prix`,`listingredient`,`idCreateur`) VALUES ('Sandwich poulet','Super bon sandwich avec poulet',3.25,'poulet/salade/pain/mayonaise/huile',2);

