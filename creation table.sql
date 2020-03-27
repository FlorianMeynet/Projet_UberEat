create database cooking;
USE `cooking`;
CREATE TABLE `cooking`.`Client` (
  `idClient` int NOT NULL,
  `nom` VARCHAR(20)  NULL,
 `prenom` VARCHAR(20) NULL,
 `adresse` VARCHAR(50) NULL,
  `ville` VARCHAR(20) NULL,
  `tel` VARCHAR(20) NULL,
  PRIMARY KEY (`idClient`) );
  
CREATE TABLE `cooking`.`Connexion` (
  `idClient` int NOT NULL,
  `motDePasse` VARCHAR(20)  NULL,
  `pseudo` VARCHAR(20) NULL,
  PRIMARY KEY (`pseudo`) );
  
  CREATE TABLE `cooking`.`fournisseur` (
`idFournisseur` int NOT NULL,
  `nomF` VARCHAR(20)  NULL,
  `tel` VARCHAR(20) NULL,
  PRIMARY KEY (`idFournisseur`) );
  
CREATE TABLE `cooking`.`Createur` (
  `idCreateur` int NOT NULL,
  `nom` VARCHAR(20) NOT NULL,
  `idClient` int NULL,
  
  PRIMARY KEY (`idCreateur`) );
  
CREATE TABLE `cooking`.`Recette` (
  `idRecette` int NOT NULL,
  `quantite` int NULL,
   `descriptif` VARCHAR(20) NULL,
   `prix` FLOAT NULL,
   `listingredient ` VARCHAR(45) NULL,
   `idCreateur` int  NULL,
   
  PRIMARY KEY (`idCreateur`));
   
CREATE TABLE `cooking`.`Ingredient` (
 `idIngredient` int NOT NULL,
  `categorie` VARCHAR(20)  NULL,
  `prixUnité` FLOAT  NULL,
  `stockMini` int NULL,
  `stockActuel` int NULL,
  `stockMax` int NULL,
  `idFournisseur` int NULL,
 PRIMARY KEY (`idIngredient`));