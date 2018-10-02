<?php
//Connexion à la base de données
$table=$_GET['table'];
include "connexion.php";

// Creation et envoi de la requete
$query = "SELECT * FROM ".$table;

$result = mysqli_query($link, $query);

$nb_col=mysqli_num_fields($result);
$nb_rows = mysqli_num_rows($result);

echo "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
echo "<liste>\n";
echo "<stat><nb>".$nb_ligne."</nb></stat>";

// Recuperation des resultats
while($row = mysqli_fetch_row($result)){
	echo "\t<".$table.">\n";
	for($i=0;$i<$nb_col;$i++)
	{
        $finfo = mysqli_fetch_field_direct($result, $i);
		echo "\t\t<".$finfo->name.">".$row[$i]."</".$finfo->name.">\n";
	}
	echo "\t</".$table.">\n";
}
echo "</liste>\n";
mysqli_free_result($result);
// Deconnexion de la base de donnees
mysqli_close();

?>
