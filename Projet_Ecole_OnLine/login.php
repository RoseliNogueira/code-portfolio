<?php session_start();

if (isset($_POST['submit'])) 
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $prenom = ""; 
        $idpersonne = "";
        $usager = $_POST['usager'];
        $pass = $_POST['pass'];
        $error="";
    
        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      

        // Check connection
        if ($conn->connect_error) 
        {
            die("Connection failed: " . $conn->connect_error);
        }
    
        //Appele à une procédure stockée en passant de paramètres
        $sql = "CALL connect('$usager', '$pass')";
        $result = $conn->query($sql);
        if ($result->num_rows > 0)
        {
            // charge chaque variable avec le contenu de la base de données
            while($row = $result->fetch_assoc())
            {
                $prenom = $row["prenom"];
                $idpersonne = $row["idpersonne"];
                $_SESSION['prenom'] = $prenom;
                $_SESSION['idpersonne'] = $idpersonne;

            }
            if ($usager == magister && $pass == signum)
            {
                header('Location:adminAddCours.php');
            }
            else
            {
                header('Location:monCompte.php');
            }
        }
        else
        {
           $error = "L'usager ou le mot de passe est incorrect, ";
           echo $error . 's\'il vous plaît, essayer à nouveau en <a href="index.php">cliquant ici</a>.'; 
        }
            $conn->close();
    }
    else
        {
            session_destroy();
            
        }
?>