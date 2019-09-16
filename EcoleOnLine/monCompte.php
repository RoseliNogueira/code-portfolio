<?php session_start();
    include 'fonctions.php';
    TeteDePage();
    AfficherMenuMonCompte();
?>
<div class="wrapper col3">
  <div id="homecontent">    
    <div class="column2">
    <h2>Bienvenue <?php if(isset($_SESSION['prenom'])) { echo $_SESSION['prenom']; } ?> !</h2> 
    <?php echo '<div id="deconnexion">';
    echo '<form name="deconnexion" action="index.php" method="post">';
    if(isset($_SESSION['prenom']))
    { echo '<p><input type="submit" class="Btn" name="btnDisconnect" value="Déconnexion"></p></form></div>';} ?>     
        <?php 
        CoursInscrit(); 
        CoursNomInscrit();
        ?>  
      </div>
    <br class="clear" />
  </div>
</div>
<?php PiedDePage(); ?>