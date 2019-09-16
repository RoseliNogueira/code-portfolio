<?php session_start();
    include 'fonctions.php';
    TeteDePage();
    AfficherMenuEnseignant();
?>
<div class="wrapper col3">
  <div id="homecontent">    
    <div class="column2">
    <h2>Tâches du tuteur en Ligne</h2>
    </br>
    <h3>Bienvenue <?php
    if(isset($_SESSION['prenom']))  {
        echo $_SESSION['prenom'];   }
    ?> !</h3> 
    <?php echo '<div id="deconnexion">';
    echo '<form name="deconnexion" action="index.php" method="post">';
    if(isset($_SESSION['prenom']))
    { echo '<p><input type="submit" class="Btn" name="btnDisconnect" value="Déconnexion"></p></form></div>';} ?>     
        <?php
            ListeAdminCours();            
        ?>  
      </div>
    <br class="clear" />
  </div>
</div>
<?php PiedDePage(); ?>