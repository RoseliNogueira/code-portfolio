<?php session_start();
if(isset($_POST['btnSoumettre']))
{
$_SESSION['prenom'] = $_POST['txtUtilisateur'];
}
else
{
    session_destroy();
}

header('Location:index.php');
?>