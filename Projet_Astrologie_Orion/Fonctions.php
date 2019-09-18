<?php

function horoscope() {
    if(isset($_POST["Naissance"]) && isset($_POST["txtPrenom"]) && isset($_POST["txtNom"])){
        $IdSoumettre = AfficherHoroscopeDuJour();
        $id = $IdSoumettre;
        $prenom = $_POST['txtPrenom'];
        $nom = $_POST['txtNom'];
    }
    else {
        $id = $_GET['id'];        
    }
    //var_dump($id);//imprimit sur l'ecran le resultat;
    try    
    {
        $servername = "localhost";
        $username = "root";
        $password = "laval";
        $dbname = "orion";
        $idbase = "";
        $signe ="";
        $datesigne = "";
        $climatastral = "";
        $humeur = "";
        $amour = "";
        $argent = "";
        $travail = "";
        $photo = "";                
        // Create connection
        $conn = new mysqli($servername, $username, $password, $dbname);        
        // Check connection
        if ($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);        
        }        
        //Appele à une procédure stockée en passant de paramètres
        $sql = "CALL horoscopes($id)";
        $result = $conn->query($sql);        
        if ($result->num_rows > 0) {
        // output data of each row
        while($row = $result->fetch_assoc()) {
            $idbase = $row["id"];
            $signe = $row["signe"];
            $datesigne = $row["datesigne"];
            $climatastral = $row["climatastral"];
            $humeur = $row["humeur"];
            $amour = $row["amour"];
            $argent = $row["argent"];
            $travail = $row["travail"];
            $photo = $row["photo"];
    }
} else {
    echo "0 results";
}
$conn->close();
    }
    catch (Exception $ex)    {
        $msg = 'erreur dans le fichier '. $ex->getFile().' Ligne:'.$ex->getLine().' message:'.$ex->getMessage();
        echo $msg;
        $valide = false;
    }    
    if($id == $idbase)    {
        echo '<div id="Images_Taureau"><img src="' . $photo . '" alt="Eau"/></div>';
        if(isset($prenom))
        {
             echo '<h2 id="Titre_Signes">Bonjour '.$prenom.' votre signe est: ' . $signe . '</h2>';
        }
        else 
        {
             echo '<h2 id="Titre_Signes">' . $signe . '</h2>';
        }
        echo '<p id="Date">Les dates du ' . $signe . ' : ' . $datesigne . '.</p>';
        echo '<table class="Horoscope_du_Jour"><tbody><tr><td colspan="2" id="Titre_HJ">Votre climat astral</td></tr>
            <tr><td colspan="2" id="Text">' . $climatastral . '</td></tr>';
        echo '<tr><td id="Titre_HJ">Humeur</td>';
        echo '<td id="Titre_HJ">Amour</td></tr>';
        echo '<tr><td id="Text">' . $amour . '</td>';
        echo '<td>' . $humeur . '</td></tr>';
        echo '<tr><td id="Titre_HJ">Argent</td>';
        echo '<td id="Titre_HJ">Travail</td></tr>';
        echo '<tr><td id="Text">' . $travail . '</td>';
        echo '<td id="Text">' . $argent . '</td></tr></tbody></table>';
    }
}

function AfficherHoroscopeDuJour()
{
//cherche la date qui était entrée
$date = $_POST['Naissance'];

//fait la convertion de la date entrée à timestamp
$timestamp = strtotime($date);
//trouve le jour de l'année qui correspond la date entrée
$dateToUseForMyTreatment = date('z', $timestamp)+1;
$signe = "";
//en utilisant comme référence le jour de l'année je fais la comparaison de la date entrée avec la date de chaque signe
switch (true)
{
    case $dateToUseForMyTreatment <=19:
        $signe = '10';
        break;
    case $dateToUseForMyTreatment <= 49:
        $signe = '11';
        break;
    case $dateToUseForMyTreatment <= 79:
        $signe = '12';
        break;    
    case $dateToUseForMyTreatment <= 109:
        $signe = '1';
        break;    
    case $dateToUseForMyTreatment <= 140:
        $signe = '2';
        break;    
    case $dateToUseForMyTreatment <= 171:
        $signe = '3';
        break;    
    case $dateToUseForMyTreatment <= 203:
        $signe = '4';
        break;    
    case $dateToUseForMyTreatment <= 234:
        $signe = '5';
        break;    
    case $dateToUseForMyTreatment <= 265:
        $signe = '6';
        break;    
    case $dateToUseForMyTreatment <= 295:
        $signe = '7';
        break;    
    case $dateToUseForMyTreatment <= 325:
        $signe = '8';
        break;
    case $dateToUseForMyTreatment <= 355:
        $signe = '9';
        break;
    case $dateToUseForMyTreatment <= 365:
        $signe = '10';
        break;
}
return $signe;
}

function TeteDePage()
{
    echo '<img id="Logo" src="Images/Logo.jpg" alt="logo"/>';
    echo '<h1 id="Titre">Astrologie Orion</h1>';
}

function AfficherMenu()
{
    echo '<ul id="menu">'; 
    echo '<li><a href="index.php">Accueil</a></li>';
    echo '<li><a href="Astrologie.php">Astrologie</a></li>';
    echo '<li><a href="#">Horoscopes</a><ul>';
    echo '<li><a href="Horoscopes.php?id=1">Bélier</a></li>';
    echo '<li><a href="Horoscopes.php?id=2">Taureau</a></li>';
    echo '<li><a href="Horoscopes.php?id=3">Gémeaux</a></li>';
    echo '<li><a href="Horoscopes.php?id=4">Cancer</a></li>';
    echo '<li><a href="Horoscopes.php?id=5">Lion</a></li>';
    echo '<li><a href="Horoscopes.php?id=6">Vierge</a></li>';
    echo '<li><a href="Horoscopes.php?id=7">Balance</a></li>';
    echo '<li><a href="Horoscopes.php?id=8">Scorpion</a></li>';
    echo '<li><a href="Horoscopes.php?id=9">Sagitaire</a></li>';
    echo '<li><a href="Horoscopes.php?id=10">Capricorne</a></li>';
    echo '<li><a href="Horoscopes.php?id=11">Verseau</a></li>';
    echo '<li><a href="Horoscopes.php?id=12">Poisson</a></li></ul>';
    echo '<li><a href="#">Signes</a><ul>';
    echo '<li><a href="Caracteristique.php">Caractéristique des signes</a></li>';
    echo '<li><a href="Traits.php">Traits des signes</a></li></ul></li>';
    echo '<li><a href="Contact.php">Contact</a></li></ul>';
}

function Login()
{    
    echo '<div id="Login">';
    echo '<form name="Login" action="login.php" method="post">';
    echo '<p><label for="txtUtilisateur">Nom d\'utilisateur :</label>';
    echo '<input type="text" name="txtUtilisateur"></p>';
    echo '<p><label for="txtPassword">Mot de passe :</label>';
    echo '<input type="password" name="txtPassword"></p>';
    if(isset($_SESSION['prenom']))
    {
        echo '<p><input type="submit" class="Btn" name="btnDisconnect" value="Déconnexion"></p></form></div>';
    }
    else
    {
        echo '<p><input type="submit" class="Btn" name="btnSoumettre" value="Soumettre"></p></form></div>';
    }
    
    
}

function HoroscopeDuJour()
{
    echo '<div id="horoscope_Today"><h3>Votre horoscope d\'aujourd\'hui</h3>';
    echo '<form name="horocopeToday" action="Horoscopes.php" method="post"><p><label for="Prenom">Prénom :</label>';
    echo '<input id="nameInput" type="text" name="txtPrenom" required ></p>';
    echo '<p><label for="Nom">Nom :</label><input type="text" name="txtNom" required ></p>';
    echo '<p><label for="Naissance">Date de naissance :</label><input type="date" name="Naissance" id="dateNaissance" required/></p>';
    echo '<p><input type="submit" class="Btn" name="btnSoumettre" value="Soumettre" ></p></form>';
}

function PiedDePage()
{
    echo '<div id="Images">';
    echo '<h3 id="Titre_pied">Les éléments</h3>';
    echo '<a href="Elements.php#Eau"><img src="Images/Eau.jpg" alt="Eau"/></a>';
    echo '<a href="Elements.php#Feu"><img src="Images/Feu.jpg" alt="Feu"/></a>';
    echo '<a href="Elements.php#Terre"><img src="Images/Terre.jpg" alt="Terree"/></a>';
    echo '<a href="Elements.php#Air"><img src="Images/Air.jpg" alt="Air"/></a></div>';
    echo '<div id="Legal">';
    echo '<h3>Politiques et conditions</h3><ul>';               
    echo '<li>Dernier mise à jour : ' . date (" d F Y ", filemtime(__FILE__)) . '</li>';
    echo '<li>Ce site a été crée par <a href="http://www.collegecdi.ca/">Orion Inc.</a></li>';
    echo '<li><small><sup>&copy</sup>2018 Astrologie Orion, Tous droits réservés</small></li></ul></div>';
    echo '<div id="Liens">';
    echo '<h3>Liens utiles et conseils</h3><ul>';
    echo '<li><a href="https://federation-astrologues.com/">Fédération des Astrologue Francophones</a></li>';
    echo '<li><a href="http://academie-francophone-astropsychologie.com/">Académie Francophone d’AstroPsychologie</a></li>';                      
    echo '<li><a href="https://www.coursastrologiebordeaux.fr/">Atelier Astrologie Aquitaine</a></li></ul></div>';
}

function Contact ()
{
    
    echo <<<_END
    <div id="Email">
        <form name="Login" action="contact.php" method="post">
            <p><label for="Nom">Nom :</label>
                <input id="txtNom" type="text" name="txtNom" required></p>
            <p><label for="Email">Votre adresse courriel :</label>
                <input id="myEmail" type="Email" name="Email" id="Courriel" required></p>
            <p><label for="Commentaire">Ecrivez-vous!</label></p>
            <textarea name="Commentaire" id="Commentaire"
                placeholder="Saisissez vos commentaires ici." cols="90"
                rows="20"></textarea>
            <p><input onclick="confirmation()" type="submit" class="Btn" name="btnSoumettre" value="Soumettre"></p>
        </form>
    </div>
    <script language="javascript" type="text/javascript" src="Email.js"></script>
_END;
    

}
?>