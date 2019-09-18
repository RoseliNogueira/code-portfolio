<?php session_start();
try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $idcours = "";
        $idpersonne = $_SESSION['idpersonne'];

        // Cree la connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check la connection
        if ($conn->connect_error) 
            {
            die("Connection failed: " . $conn->connect_error);
            }
            
            //Récupérer les donnes qui était cochent
            $debut = 1;
            $fin = 100;
            
            while($debut <= $fin)
                {
                if(isset($_POST[$debut]))//cherche le nom (le nom est l'idcours) du checkbox
                    {
                        //Appele à une procédure stockée en passant de paramètres
                        $sql = "CALL add_inscription('$debut','$idpersonne')";
                        $conn->query($sql);                        
                    }
                    $debut++;
                }
        $conn->close();
        header('Location:monCompte.php');
    }
    catch (Exception $ex)    
    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
    
?>