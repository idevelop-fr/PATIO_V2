<?php
/*Connexion à la base de données*/
$requete=$_GET['requete'];
include "connexion.php";

$requete = str_replace("@@@","'",$requete);

$result = mysqli_query($link, $requete);

echo "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
/*echo "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";*/

if(!$result)
{	exit("<liste><stat><nb>0</nb><error>".mysqli_error($link)."</error></stat></liste>");}

$nb_col=mysqli_num_fields($result);
$nb_rows = mysqli_num_rows($result);

echo "<liste>\n";

echo "\t<stat>\n";
echo "\t\t<nb>".$nb_rows."</nb>\n";
echo "\t\t<error>".mysqli_error($link)."</error>\n";
echo "\t</stat>\n";

/* Recuperation des resultats*/
while($row = mysqli_fetch_row($result)){
	echo "\t<dataset>\n";
	for($i=0;$i<$nb_col;$i++)
	{
        $finfo = mysqli_fetch_field_direct($result, $i);
		/*echo "\t\t<".$finfo->name.">".$row[$i]."</".$finfo->name.">\n";*/
		echo "\t\t<".$finfo->name.">".utf8_encode($row[$i])."</".$finfo->name.">\n";
	}
	echo "\t</dataset>\n";
}
echo "</liste>\n";
mysqli_free_result($result);
// Deconnexion de la base de donnees
mysqli_close($link);

?>
