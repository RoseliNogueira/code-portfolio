<?php
    include 'fonctions.php';
    TeteDePage();
    Login();
    AfficherMenu();    
?>

<div class="wrapper col3">
  <div id="container">
    <div id="content">
      <h1>Addiction de cours</h1>
      <div id="respond">
        <form action="creeCompte.php" method="post">
          <p>
              <label for="prenom">Prenom </label>
              <input type="text" name="prenom" id="prenom" value="" size="22" required/>            
          </p>
          <p>
              <label for="nom">Nom </label>
              <input type="text" name="nom" id="nom" value="" size="22" required/>            
          </p>          
          <p>
              <label for="phone">Téléphone </label>
              <input type="text" name="phone" id="phone" value="" size="22" required/>            
          </p>
          <p>
              <label for="email">Adresse courriel </label>
              <input type="text" name="email" id="email" value="" size="22" required/>            
          </p>
          <p>
              <label for="usager">Usager </label>
              <input type="text" name="usager" id="usager" value="" size="22" required/>
          </p>
              <label for="motdepasse">Mot de passe </label>
              <input type="password" name="motdepasse" id="motdepasse" value="" required/>
          </p>
          <p>
            <input name="submit" type="submit" id="submit" value="Submit Form" />
            &nbsp;
            <input name="reset" type="reset" id="reset" tabindex="5" value="Reset Form" />
          </p>
        </form>
      </div>      
    </div>      
    <div class="clear"></div>
  </div>
</div>
<?php PiedDePage(); ?>