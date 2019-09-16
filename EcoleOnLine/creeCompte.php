<?php
include 'fonctions.php';
    TeteDePage();
    Login();
    AfficherMenu();
try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        
        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error) 
            {
                die("Connection failed: " . $conn->connect_error);
            }
            //recupere le donnée entré dans le formulaire Crée un compte            
            $prenom = $_POST['prenom'];
            $nom = $_POST['nom'];
            $phone = $_POST['phone'];
            $email = $_POST['email'];
            $usager = $_POST['usager'];
            $motdepasse = $_POST['motdepasse'];

            //Appele à une procédure stockée en passant de paramètres
            $sql = "CALL add_etudiant('$prenom', '$nom', '$phone', '$email', '$usager', '$motdepasse')";
            $conn->query($sql);
       
            $conn->close();
    }
    
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
      
    
    PiedDePage();
?>
