<?php
//Connexion à la base de données
include 'connexion.php';

$iduser=$_GET["iduser"];
$mdp=$_GET["mdp"];

// Creation et envoi de la requete
$query = "SELECT COUNT(*) FROM table_valeur";

if ($result = mysqli_query($link, $query)) {
	// Recuperation des resultats
	while ($row = mysqli_fetch_row($result)) {
		printf($row[0]);
	}
	mysqli_free_result($result);
}

// Deconnexion de la base de donnees
mysqli_close($link);

?>
