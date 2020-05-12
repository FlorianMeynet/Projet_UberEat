use tableprojet;
select * from client;
select * from createur;
select * from ingredient;
select * from stock;
select * from recette;
select * from liste_ingredient;
select * from list_recette;
select * from cuisinier;
select * from commande;
select * from fournisseur;

UPDATE `tableprojet`.`client` SET  `capitalCooks` =10 WHERE (`idClient` = 1);