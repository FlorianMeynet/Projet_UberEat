-- MySQL Workbench Synchronization
-- Generated: 2020-05-05 14:46
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: asus
drop database tableprojet;
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `TableProjet` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Createur` (
  `idCreateur` INT(11) NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(45) NULL DEFAULT '\"Chef Jason\"',
  `idClient` INT(11) NOT NULL, 
  PRIMARY KEY (`idCreateur`),
  UNIQUE INDEX `idCreateur_UNIQUE` (`idCreateur` ASC) VISIBLE,
  INDEX `fk_Createur_Client1_idx` (`idClient` ASC) VISIBLE,
  CONSTRAINT `fk_Createur_Client1`
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
  `idCreateur` INT(11) NULL DEFAULT NULL,
  `categorie` VARCHAR(45) NULL DEFAULT 'Plat',
  PRIMARY KEY (`idRecette`),
  INDEX `idCreateur_idx` (`idCreateur` ASC) VISIBLE,
  UNIQUE INDEX `idRecette_UNIQUE` (`idRecette` ASC) VISIBLE,
  UNIQUE INDEX `Nom_UNIQUE` (`Nom` ASC) VISIBLE,
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
  `motDePasse` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idClient`),
  UNIQUE INDEX `idClient_UNIQUE` (`idClient` ASC) VISIBLE,
  UNIQUE INDEX `adresseEmail_UNIQUE` (`adresseEmail` ASC) VISIBLE,
  UNIQUE INDEX `numeroDeTelephone_UNIQUE` (`numeroDeTelephone` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Ingredient` (
  `idIngredient` INT(11) NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(20) NULL DEFAULT NULL,
  `categorie` VARCHAR(4) NOT NULL,
  `prixUnité` FLOAT(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`idIngredient`),
  UNIQUE INDEX `idIngredient_UNIQUE` (`idIngredient` ASC) VISIBLE,
  UNIQUE INDEX `Nom_UNIQUE` (`Nom` ASC) VISIBLE)
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

CREATE TABLE IF NOT EXISTS `TableProjet`.`stock` (
  `idstock` INT(11) NOT NULL AUTO_INCREMENT,
  `idIngredient` INT(11) NULL DEFAULT NULL,
  `quantiteMin` FLOAT(11) NULL DEFAULT NULL,
  `quantiteMax` FLOAT(11) NULL DEFAULT NULL,
  `quantite` FLOAT(11) NULL DEFAULT NULL,
  `idfournisseur` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idstock`),
  INDEX `idIngredient_idx` (`idIngredient` ASC) VISIBLE,
  INDEX `idFournisseur_idx` (`idfournisseur` ASC) VISIBLE,
  UNIQUE INDEX `idstock_UNIQUE` (`idstock` ASC) VISIBLE,
  CONSTRAINT `idIngredient`
    FOREIGN KEY (`idIngredient`)
    REFERENCES `TableProjet`.`Ingredient` (`idIngredient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idFournisseur`
    FOREIGN KEY (`idfournisseur`)
    REFERENCES `TableProjet`.`Fournisseur` (`idFournisseur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Commande` (
  `idCommande` INT(11) NOT NULL AUTO_INCREMENT,
  `idClient` INT(11) NULL DEFAULT NULL,
  `date_commande` DATETIME NULL DEFAULT NULL,
  `idCuisinier` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idCommande`),
  UNIQUE INDEX `idCommande_UNIQUE` (`idCommande` ASC) VISIBLE,
  INDEX `idClient_idx` (`idClient` ASC) VISIBLE,
  INDEX `idCuisinier_idx` (`idCuisinier` ASC) VISIBLE,
  CONSTRAINT `idClient`
    FOREIGN KEY (`idClient`)
    REFERENCES `TableProjet`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idCuisinier`
    FOREIGN KEY (`idCuisinier`)
    REFERENCES `TableProjet`.`Cuisinier` (`idCuisinier`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Cuisinier` (
  `idCuisinier` INT(11) NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(45) NULL DEFAULT NULL,
  `Prenom` VARCHAR(45) NULL DEFAULT NULL,
  `Salaire` FLOAT(11) NULL DEFAULT NULL,
  `nombre_commande` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idCuisinier`),
  UNIQUE INDEX `idCuisinier_UNIQUE` (`idCuisinier` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`Liste_ingredient` (
  `idRecette1` INT(11) NOT NULL,
  `IdIngredient1` INT(11) NOT NULL,
  `quantite` FLOAT(11) NULL DEFAULT NULL,
  INDEX `idRecette_idx` (`idRecette1` ASC) VISIBLE,
  INDEX `idIngredient_idx` (`IdIngredient1` ASC) VISIBLE,
  PRIMARY KEY (`idRecette1`, `IdIngredient1`),
  CONSTRAINT `idRecette1`
    FOREIGN KEY (`idRecette1`)
    REFERENCES `TableProjet`.`Recette` (`idRecette`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `idIngredient1`
    FOREIGN KEY (`IdIngredient1`)
    REFERENCES `TableProjet`.`Ingredient` (`idIngredient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `TableProjet`.`List_recette` (
  `idRecette2` INT(11) NOT NULL,
  `idCommande2` INT(11) NOT NULL,
  `quantite` INT(11) NULL DEFAULT NULL,
  INDEX `idCommande_idx` (`idCommande2` ASC) VISIBLE,
  PRIMARY KEY (`idRecette2`, `idCommande2`),
  CONSTRAINT `idRecette2`
    FOREIGN KEY (`idRecette2`)
    REFERENCES `TableProjet`.`Recette` (`idRecette`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idCommande2`
    FOREIGN KEY (`idCommande2`)
    REFERENCES `TableProjet`.`Commande` (`idCommande`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;





INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Claude','Jean','rue de la paie','bourg','1957-11-24',0674586954,'jean.claude@orange.fr',0,0,'1234');
INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Morin','Loic','rue du tarpin','marseille','1999-04-18',0685314692,'morin.loic@gmail.fr',0,10000,'caca');
INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Meynet','Florian','rue de la boulangerie','perrognier','1998-02-17',067458365,'meynet.florian@orange.fr',0,10000,'mdpfacile');
INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Admin','Admin','ESILV','PARIS','1800-01-10',0000,'admin',1,1000000,'admin');
INSERT INTO `tableprojet`.`client` (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) VALUES ('Client','Client','ESILV','PARIS','1800-01-10',100,'client',0,1000000,'client');

INSERT INTO `tableprojet`.`createur` (`Nom`,`idClient`) VALUES ('Le cuisto de marseille',2);
INSERT INTO `tableprojet`.`createur` (`Nom`,`idClient`) VALUES ('Le cuisto de haute savoie',3);
INSERT INTO `tableprojet`.`createur` (`Nom`,`idClient`) VALUES ('Admin',4);


INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0682197635,'France boisson');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0785314587,'Les produits laitiers');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0647365218,'Carrefour');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0725361426,'Intermarché');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0725381426,'Alimentation');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0725369426,'Franprix');
INSERT INTO `tableprojet`.`fournisseur` (`telephone`,`Nom`) VALUES (0725369726,'Primeur');



INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Biere','u',2);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Thai','kg',2.74);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Long','kg',1.99);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Spaghetti','kg',0.90);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Oeufs','u',2);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Farine','kg',2.10);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Sucre','kg',4);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Caviar','kg',50);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Piment','kg',5);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Poivrons','u',3);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Oignons','kg',1.5);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Poulet','kg',12);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Salade','kg',14);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Huile','L',12);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Pain','u',0.8);
INSERT INTO `tableprojet`.`ingredient` (`Nom`,`categorie`,`prixUnité`) VALUES ('Mayonnaise','L',8);

INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (1,5,50,20,1);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (2,2,10,3,3);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (3,2,10,5,3);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (4,2,10,4,4);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (5,4,20,6,3);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (6,4,20,6,3);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (7,3,20,6,5);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (8,2,20,6,3);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (9,1,20,6,4);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (10,1,20,6,5);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (11,1,20,6,2);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (12,3,20,6,5);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (13,2,20,6,3);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (14,1,20,6,2);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (15,1,20,6,6);
INSERT INTO `tableprojet`.`stock` (`idingredient`,`quantiteMin`,`quantiteMax`,`quantite`,`idfournisseur`) VALUES (16,1,20,6,7);


INSERT INTO `tableprojet`.`cuisinier` ( `Nom`, `Prenom`, `Salaire`, `nombre_commande`) VALUES ('jean', 'Yves', '10', '0');
INSERT INTO `tableprojet`.`cuisinier` (`Nom`, `Prenom`, `Salaire`, `nombre_commande`) VALUES ('licie', 'Mcdo', '100', '0');
INSERT INTO `tableprojet`.`cuisinier` (`Nom`, `Prenom`, `Salaire`, `nombre_commande`) VALUES ('oic', 'movais', '210', '0');
INSERT INTO `tableprojet`.`cuisinier` (`Nom`, `Prenom`, `Salaire`, `nombre_commande`) VALUES ('Fun', 'Louis', '5410', '0');


