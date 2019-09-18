<?php 

function TeteDePage()
{
echo <<<_END
<!DOCTYPE>
<head>
<title>Ecole En Ligne</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link rel="stylesheet" href="layout/styles/layout.css" type="text/css" />
<script type="text/javascript" src="layout/scripts/jquery.min.js"></script>
<script type="text/javascript" src="layout/scripts/jquery.slidepanel.setup.js"></script>
<!-- Homepage Only Scripts -->
<script type="text/javascript" src="layout/scripts/jquery.cycle.min.js"></script>
<script type="text/javascript">
$(function() {
    $('#featured_slide').after('<div id="fsn"><ul id="fs_pagination">').cycle({
        timeout: 5000,
        fx: 'fade',
        pager: '#fs_pagination',
        pause: 1,
        pauseOnPagerHover: 0
    });
});
</script>
<!-- End Homepage Only Scripts -->
</head>
_END;
}

function Login()
{
    echo <<<_END
    <body>
    <div class="wrapper col0">
    <div id="topbar">
    <div id="slidepanel">
    <div class="topbox"> </div>        
    <div class="topbox">
    <h2>Portail</h2>
    <form action="login.php" method="post">            
        <fieldset>
        <label for="usager">Usager:
        <input type="text" name="usager" id="usager" value="" required/></label>
        <label for="pass">Mot de Passe:
        <input type="password" name="pass" id="pass" value="" required/></label>
        <label for="remember">
        <input class="checkbox" type="checkbox" name="etudiantremember" id="etudiantremember" checked="checked" />
        Mémoriser mes renseignements </label> 
        <p><input type="submit" name="submit" id="submit" value="Connexion" />
        &nbsp;
        <input type="reset" name="reset" id="reset" value="Réinitialiser"/></p>
        <p>Si vous n'avez pas de compte étudiant, <label><a href="inscription.php">Enregistrez-vous en cliquant ici.</a></label></p>
        </fieldset>            
        </form>
        </div>
        <br class="clear" />
        </div>
        <div id="loginpanel">
        <ul>
        <li class="left">Connecter &raquo;</li>
        <li class="right" id="toggle"><a id="slideit" href="#slidepanel">Portail</a><a id="closeit" style="display: none;" href="#slidepanel">Fermer Portail</a></li>
        </ul>
        </div>
        <br class="clear" />
        </div>
        </div>
_END;
}

function AfficherMenu()
{
    echo <<<_END
    <div class="wrapper col1">
  <div id="header">
    <div id="logo">
      <h1><a href="index.html">Ecole En Ligne</a></h1>
      <p>Le meilleur est garde pour vous!</p>
    </div>
    <div id="topnav">
      <ul>
        <li class="active"><a href="index.php">Accueil</a></li>
        <li><a href="cours.php">Cours</a></li>
      </ul>
    </div>
    <br class="clear" />
  </div>
</div>
_END;
}

function AfficherMenuMonCompte()
{
    echo <<<_END
    <div class="wrapper col1">
  <div id="header">
    <div id="logo">
      <h1><a href="index.html">Ecole En Ligne</a></h1>
      <p>Le meilleur est garde pour vous!</p>
    </div>
    <div id="topnav">
      <ul>
        <li class="active"><a href="monCompte.php">Mon Compte</a></li>
      </ul>
    </div>
    <br class="clear" />
  </div>
</div>
_END;
}

function AfficherMenuEnseignant()
{
    echo <<<_END
    <div class="wrapper col1">
  <div id="header">
    <div id="logo">
      <h1><a href="index.html">Ecole En Ligne</a></h1>
      <p>Le meilleur est garde pour vous!</p>
    </div>
    <div id="topnav">
      <ul>
        <li class="active"><a href="adminAddCours.php">Additionner Cours</a></li>
        <li><a href="adminSuppCours.php">Supprimer Cours</a></li>
        <li><a href="adminListeCours.php">Liste des Cours</a></li>
      </ul>
    </div>
    <br class="clear" />
  </div>
</div>
_END;
}

function PiedDePage()
{
    echo <<<_END
    <div class="wrapper col4"></div>
    <div class="wrapper col5">
    <div id="copyright">
    <p class="fl_left">Copyright &copy; 2018 École En Ligne - Tous droits réservés</p>
    <br class="clear" />
    </div></div></body></html>
_END;
}

function Slide()
{
    echo <<<_END
<div class="wrapper col2">
  <div id="featured_slide">
    <div class="featured_box"><a href="#"><img src="images/image.jpg" alt="" /></a>
      <div class="floater">
        <h2>1. Formation condensée</h2>
        <p>Démarrez la carrière dont vous avez toujours rêvé avec une formation de haute qualité qui vous permettra d’atteindre vos objectifs professionnels! 
            Nos programmes accélérés sont conçus pour répondre aux besoins du marché du travail et peuvent être complétés en quelques mois seulement!.</p>        
      </div>
    </div>
    <div class="featured_box"><a href="#"><img src="images/image1.jpg" alt="" /></a>
      <div class="floater">
        <h2>2. Programmes reconnus</h2>
        <p>Tous les programmes que nous proposons au Québec sont reconnus par le ministère de l’Éducation et de l’Enseignement supérieur (MEES)!
            La plupart de nos programmes incluent un stage en milieu professionnel afin que vous puissiez mettre en pratique les connaissances 
            et compétences acquises en classe.</p>      
      </div>
    </div>
    <div class="featured_box"><a href="#"><img src="images/image2.jpg" alt="" /></a>
      <div class="floater">
        <h2>3. Taux de placement élevés</h2>
        <p>En 2014, plus de 87 % de nos diplômés avaient décroché un emploi dans les 12 mois suivant leur formation !</p>
      </div>
    </div>
  </div>
</div>
_END;
}

function Cours()
{    
    try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $titre = "";
        $description = "";
        $duree = "";
        $prix = "";

        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error)
            {
            die("Connection failed: " . $conn->connect_error);
            } 
        
        //Appele à une procédure stockée en passant de paramètres
        $sql = "CALL select_cours_actifs()";
        $result = $conn->query($sql);
        if ($result->num_rows > 0) {
        // output info of each row
    echo <<<_END
    <div class="wrapper col3">
    <div id="homecontent">    
    <div class="column2">
        <h2>Cours offerts</h2>
        <table summary="Summary Here" cellpadding="0" cellspacing="0">
        <thead><tr>
            <th>Cours</th>
            <th>Description</th>
            <th>Durée</th>
        </tr></thead><tbody>          
_END;
        while($row = $result->fetch_assoc()) {
            $titre = $row["titre"];
            echo '<tr class="light"><td>' . $titre . '</td>';
            $description = $row["description"];
            echo '<td>' . $description . '</td>';
            $duree = $row["duree"];
            echo '<td>' . $duree . ' heures</td>';            
    }
    echo <<<_END
    </tbody></table></div>
    <br class="clear" /></div>
    </div>
_END;
} else {
    echo "<p>Il n'y a pas de cours offerts pour le moment.</p>";
}
$conn->close();
    }
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
}

function CoursInscrit()
{    
    try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $titre = "";        
        $idpersonne = $_SESSION['idpersonne'];

        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error) 
            {
            die("Connection failed: " . $conn->connect_error);
            } 
        
        //Appele à une procédure stockée en passant de paramètres
        $sql = "CALL cours_inscrit('$idpersonne')";
        $result = $conn->query($sql);
        if ($result->num_rows > 0)
            {
        // output info of each row
    echo <<<_END
    <div class="wrapper col3">
    <div id="homecontent">    
    <div class="column2">
    <h2>Cours inscrit</h2>
      <table summary="Summary Here" cellpadding="0" cellspacing="0">
        <thead>
          <tr>
            <th>Cours</th>
          </tr>
        </thead>
        <tbody>          
_END;
        while($row = $result->fetch_assoc()) {
            $titre = $row["titre"];
            echo '<tr class="light"><td>' . $titre . '</td>';            
    }
    echo <<<_END
        </tbody>
      </table>        
    </div>
    <br class="clear" />
    </div>
    </div>
_END;
} else {
    echo "<h2>Vous n'êtes pas inscrit à des cours, vérifier en bas les cours que sont disponibles pour l'inscription.</h2>";
}
$conn->close();
    }
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
}
 
function CoursNomInscrit()
{    
    try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $idcours = "";
        $titre = "";        
        $description = "";
        $duree = "";
        $idpersonne = $_SESSION['idpersonne'];

        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error) 
            {
            die("Connection failed: " . $conn->connect_error);
            }         
        
        //Appele à une procédure stockée en passant de paramètres
        $sql = "CALL cours_non_inscrit('$idpersonne')";
        $result = $conn->query($sql);
        if ($result->num_rows > 0) 
            {
            // output info of each row
            echo <<<_END
            <div class="wrapper col3">
          <div id="homecontent">    
            <div class="column2">
                <h2>Cours à s'inscrit</h2>
                <table summary="Summary Here" cellpadding="0" cellspacing="0">
                <thead>
                  <tr>
                    <th>Choix</th>
                    <th>Cours</th>
                    <th>Description</th>
                    <th>Durée</th>
                  </tr>
                </thead>
                <tbody>          
_END;
        while($row = $result->fetch_assoc()) 
            {
            $idcours = $row["idcours"];            
            echo '<tr class="light"><td><form action="addInscriptionCours.php" method="post">';            
            echo '<input type="checkbox" name="'.$idcours.'" id="$titre" unchecked/></label></td>';
            $titre = $row["titre"];
            echo '<td>' . $titre . '</td>';
            $description = $row["description"];
            echo '<td>' . $description . '</td>';
            $duree = $row["duree"];
            echo '<td>' . $duree . ' heures</td></tr>';
            }
            echo <<<_END
            </tbody>
              </table>        
              </div>
            <br class="clear" />
          </div>
        </div>
_END;
            echo '<p><input type="submit" name="coursainscrit" id="coursainscrit" value="inscrire" />';
            echo '&nbsp;';
            echo '<input type="reset" name="coursreset" id="coursreset" value="Reset"/></p></form>';
            }            
else 
    {
    echo "Felicitation ! Vous êtes inscrit à tous les cours qu'on a disponibles pour le moment.";
    }

$conn->close();
    }
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
}

function FormAddCours()
{
    echo <<<_END
    <div class="wrapper col3">
  <div id="container">
    <div id="content">
      <h1>Additionner des cours au programme en ligne</h1>
      <div id="respond">
          <form action="addCours.php" method="post">
          <p>
              <label for="titre">Titre du cours : </label>
              <input type="text" name="titre" id="titre" value="" required/>            
          </p>
          <p>
              <label for="description">Description : </label>
              <input type="text" name="description" id="description" value="" required/>            
          </p>          
          <p>
              <label for="duree">Durée du cours (en heures) : </label>
              <input type="text" name="duree" id="duree" value="" required/>            
          </p>          
          <p>
            <input name="submit" type="submit" id="submit" value="Confirmer" />
            &nbsp;            
            <input name="reset" type="reset" id="reset" tabindex="5" value="Réinitialiser" />
          </p>
        </form>
      </div>      
    </div> 
        
    <div class="clear"></div>
  </div>
</div>
_END;
}

function FormSuppCours()
{
    try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $idcours = "";
        $titre = "";        
        $description = "";
        $duree = "";
        $prix = "";

        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error) 
            {
            die("Connection failed: " . $conn->connect_error);
            }         
        
        //Appele à une procédure stockée
        $sql = "CALL select_cours_actifs()";
        $result = $conn->query($sql);
        if ($result->num_rows > 0) 
            {
            // output info of each row
            echo <<<_END
            <br class="clear" />
            <h2>Supprimer cours</h2>
            <table summary="Summary Here" cellpadding="0" cellspacing="0">
            <thead>
            <tr>
                <th>Choix</th>
                <th>Cours</th>
                <th>Description</th>
                <th>Durée</th>
            </tr>
            </thead>
            <tbody>          
_END;
        while($row = $result->fetch_assoc()) 
            {
            $idcours = $row["idcours"];  
            $_SESSION['idcours'] = $idcours;
            echo '<tr class="light"><td><form action="supprimerCours.php" method="post">';            
            echo '<input type="checkbox" name="'.$idcours.'" unchecked/></label></td>';
            $titre = $row["titre"];
            echo '<td>' . $titre . '</td>';
            $description = $row["description"];
            echo '<td>' . $description . '</td>';
            $duree = $row["duree"];
            echo '<td>' . $duree . ' heures</td></tr>';
            }
            echo <<<_END
            </tbody>
            </table>        
            <br class="clear" />
_END;
            echo '<p><input type="submit" name="suppcours" id="suppcours" value="Supprimer" />';
            echo '&nbsp;';
            echo '<input type="reset" name="suppcoursreset" id="suppcoursreset" value="Reset"/></p></form>';
            }            
            else 
                {
                echo "Il n'y a pas des cours actifs pour le moment.";
                }

        $conn->close();
    }
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
}

function ListeAdminCoursActifs()
{    
    try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $idcours = "";
        $titre = "";
        $description = "";
        $duree = "";
        $prix = "";

        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error)
            {
            die("Connection failed: " . $conn->connect_error);
            } 
        
        //Appele à une procédure stockée en passant de paramètres
        $sql = "CALL select_cours_actifs()";
        $result = $conn->query($sql);
        if ($result->num_rows > 0) {
        // output info of each row
    echo <<<_END
    <div class="wrapper col3">
    <div id="homecontent">    
    <div class="column2">
        <h2>Liste des Cours Actifs</h2>
        <table summary="Summary Here" cellpadding="0" cellspacing="0">
        <thead><tr>
            <th>ID</th>
            <th>Cours</th>
            <th>Description</th>
            <th>Durée (heure)</th>
        </tr></thead><tbody>          
_END;
        while($row = $result->fetch_assoc()) {
            $idcours = $row["idcours"];
            echo '<tr class="light"><td>' . $idcours . '</td>';
            $titre = $row["titre"];
            echo '<td>' . $titre . '</td>';
            $description = $row["description"];
            echo '<td>' . $description . '</td>';
            $duree = $row["duree"];
            echo '<td>' . $duree . ' heures</td></tr>';            
    }
    echo <<<_END
    </tbody></table></div>
    <br class="clear" /></div>
    </div>
_END;
} else {
    echo "<p>Il n'y a pas de cours actifs pour le moment.</p>";
}
$conn->close();
    }
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
}

function ListeAdminCoursInactifs()
{    
    try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $idcours = "";
        $titre = "";
        $description = "";
        $duree = "";
        $prix = "";

        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error)
            {
            die("Connection failed: " . $conn->connect_error);
            } 
        
        //Appele à une procédure stockée en passant de paramètres
        $sql = "CALL select_cours_inactifs()";
        $result = $conn->query($sql);
        if ($result->num_rows > 0) {
        // output info of each row
    echo <<<_END
    <div class="wrapper col3">
    <div id="homecontent">    
    <div class="column2">
        <h2>Liste des Cours Inactifs</h2>
        <table summary="Summary Here" cellpadding="0" cellspacing="0">
        <thead><tr>
            <th>ID</th>
            <th>Cours</th>
            <th>Description</th>
            <th>Durée (heure)</th>
        </tr></thead><tbody>          
_END;
        while($row = $result->fetch_assoc()) {
            $idcours = $row["idcours"];
            echo '<tr class="light"><td>' . $idcours . '</td>';
            $titre = $row["titre"];
            echo '<td>' . $titre . '</td>';
            $description = $row["description"];
            echo '<td>' . $description . '</td>';
            $duree = $row["duree"];
            echo '<td>' . $duree . ' heures</td></tr>';            
    }
    echo <<<_END
    </tbody></table></div>
    <br class="clear" /></div>
    </div>
_END;
} else {
    echo "<p>Il n'y a pas de cours inactifs pour le moment.</p>";
}
$conn->close();
    }
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
}

function ListeAdminCours()
{    
    try    
    {
        $servername = "localhost";
        $username = "Rose";
        $password = "Teste01!";
        $dbname = "ecoleenligne";
        $idcours = "";
        $titre = "";
        $description = "";
        $duree = "";
        $prix = "";
        $status = "";

        // Create connection
        $conn = mysqli_connect($servername, $username, $password, $dbname);      
        
        // Check connection
        if ($conn->connect_error)
            {
            die("Connection failed: " . $conn->connect_error);
            } 
        
        //Appele à une procédure stockée en passant de paramètres
        $sql = "CALL select_cours()";
        $result = $conn->query($sql);
        if ($result->num_rows > 0) {
        // output info of each row
    echo <<<_END
    <div class="wrapper col3">
    <div id="homecontent">    
    <div class="column2">
        <h2>Liste des Cours Inactifs</h2>
        <table summary="Summary Here" cellpadding="0" cellspacing="0">
        <thead><tr>
            <th>ID</th>
            <th>Cours</th>
            <th>Description</th>
            <th>Durée</th>
            <th>Status</th>
        </tr></thead><tbody>          
_END;
        while($row = $result->fetch_assoc()) {
            $idcours = $row["idcours"];
            echo '<tr class="light"><td>' . $idcours . '</td>';
            $titre = $row["titre"];
            echo '<td>' . $titre . '</td>';
            $description = $row["description"];
            echo '<td>' . $description . '</td>';
            $duree = $row["duree"];
            echo '<td>' . $duree . ' heures</td>';
            $status = $row["status"];
            if($status == 1) { $status = "Actif"; }
            else { $status = "Inactif";}
            echo '<td>' . $status . '</td></tr>';            
    }
    echo <<<_END
    </tbody></table></div>
    <br class="clear" /></div>
    </div>
_END;
} else {
    echo "<p>Il n'y a pas de cours inactifs pour le moment.</p>";
}
$conn->close();
    }
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }
}
?>

