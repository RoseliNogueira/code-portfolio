<?php session_start();
    include 'fonctions.php';
    TeteDePage();
    Login();
    AfficherMenu();
    Slide();
?>

<div class="wrapper col3">
  <div id="homecontent">    
    <div class="column2">
        <h2>Bienvenue à École En Ligne !</h2>        
        <p>Depuis plus de 40 ans, le Collège en Ligne permet à des milliers d'étudiants 
            d'entamer des carrières fructueuses.</p>
        <p>Afin de préparer adéquatement ces étudiants au marché du travaiul, nos programmes
            de formation sont axés sur la pratique et ils sont offerts par des enseignants 
            chevronnés qui ont accumulé plusieurs années d'expériences das leur domaine respectif.</p>
        <p>En tant que chef de file dans le secteur de la formation collégiale et professionnelle 
            au pays, les programmes que nous proposons permettent aux étudiants d'acquérir les 
            compétences les plus recherchées par les employeurs.</p>
      </div>
    <br class="clear" />
  </div>
</div>

<?php PiedDePage(); ?>