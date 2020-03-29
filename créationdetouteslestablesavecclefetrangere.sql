
INSERT INTO `tableprojet`.`client` (`idClient`,`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`) VALUES (1,'Claude','Jean','rue de la paie','bourg','1957-11-24',0674586954,'jean.claude@orange.fr',0,0);
INSERT INTO `tableprojet`.`client` (`idClient`,`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`) VALUES (2,'Morin','Loic','rue du tarpin','marseille','1999-04-18',0685314692,'morin.loic@gmail.fr',0,10000);
INSERT INTO `tableprojet`.`client` (`idClient`,`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`) VALUES (3,'Meynet','Florian','rue de la boulangerie','perrognier','1998-02-17',067458365,'meynet.florian@orange.fr',0,10000);

INSERT INTO `tableprojet`.`createur` (`idCreateur`,`Nom`,`idClient`) VALUES (1,'Le cuisto de marseille',2);
INSERT INTO `tableprojet`.`createur` (`idCreateur`,`Nom`,`idClient`) VALUES (2,'Le cuisto de haute savoie',3);

INSERT INTO `tableprojet`.`identifiantmotdepasse` (`id`,`motDePasse`,`Identifiant`,`idClient`) VALUES (0,'admin','admin',0);
INSERT INTO `tableprojet`.`identifiantmotdepasse` (`id`,`motDePasse`,`Identifiant`,`idClient`) VALUES (1,'claude','jean',1);
INSERT INTO `tableprojet`.`identifiantmotdepasse` (`id`,`motDePasse`,`Identifiant`,`idClient`) VALUES (2,'morin','loic',2);
INSERT INTO `tableprojet`.`identifiantmotdepasse` (`id`,`motDePasse`,`Identifiant`,`idClient`) VALUES (3,'meynet','florian',3);

INSERT INTO `tableprojet`.`fournisseur` (`idFournisseur`,`telephone`,`Nom`) VALUES (1,0682197635,'France boisson');
INSERT INTO `tableprojet`.`fournisseur` (`idFournisseur`,`telephone`,`Nom`) VALUES (2,0785314587,'Les produits laitiers');
INSERT INTO `tableprojet`.`fournisseur` (`idFournisseur`,`telephone`,`Nom`) VALUES (3,0647365218,'Carrefour');
INSERT INTO `tableprojet`.`fournisseur` (`idFournisseur`,`telephone`,`Nom`) VALUES (4,0725361426,'Intermarché');

INSERT INTO `tableprojet`.`ingredient` (`idIngredient`,`idFournisseur`,`nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (1,'Biere',1,'boisson',2,10,50,200);
INSERT INTO `tableprojet`.`ingredient` (`idIngredient`,`idFournisseur`,`nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (2,'Thai',3,'riz',2.74,2,10,20);
INSERT INTO `tableprojet`.`ingredient` (`idIngredient`,`idFournisseur`,`nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (3,'Long',3,'riz',1.99,2,10,20);
INSERT INTO `tableprojet`.`ingredient` (`idIngredient`,`idFournisseur`,`nom`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (4,'Spaghetti',4,'pate',3,2,10,20);
INSERT INTO `tableprojet`.`ingredient` (`idIngredient`,`Nom`,`idFournisseur`,`categorie`,`prixUnité`,`stockMini`,`stockActuel`,`stockMax`) VALUES (5,'Carotte',4,'legume',1.14,2,5,10);

INSERT INTO `tableprojet`.`recette` (`idRecette`,`Nom`,`descriptif`,`prix`,`listingredient`,`idCreateur`) VALUES (1,'Sandwich poulet','Super bon sandwich avec poulet',3.25,'poulet/salade/pain/mayonaise/huile',2);

