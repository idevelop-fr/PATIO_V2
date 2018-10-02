<?php
//Connexion à la base de données
include 'connexion.php';

$requete=$_GET['requete'];

$requete = str_replace("@@@","'",$requete);

mysqli_query($link, "SET NAMES UTF8");

//Suppression des \
$query = str_replace("\\", "", $requete);

// Creation et envoi de la requete
$nb_erreur=0;

$result= mysqli_query($link, $requete);

if(!$result)
{
	echo $requete."\n\n".mysqli_error($link);
	$nb_erreur+=1;
}

if($nb_erreur == 0)
{
	 echo "1";
}
// Deconnexion de la base de donnees
mysqli_close($link);
?>
