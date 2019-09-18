<?php session_start();
try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $titre = "";
        $description = "";
        $duree = "";
        
        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error) 
            {
                die("Connection failed: " . $conn->connect_error);
            }
            //recupere le donnée entré dans le formulaire: Crée un compte            
            $titre = $_POST['titre'];
            $description = $_POST['description'];
            $duree = $_POST['duree'];
            //Appele à une procédure stockée en passant de paramètres
            $sql = "CALL add_cours('$titre', '$description', '$duree')";
            $conn->query($sql);
            echo 'Cours cree avec succès !';
     
            $conn->close();
    }
    
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
    header('Location:adminAddCours.php');    
?>