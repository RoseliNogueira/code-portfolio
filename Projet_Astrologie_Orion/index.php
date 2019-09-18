<?php session_start();

include 'header.php'; ?>
        <section id="Contenu">
            <article>                
                <h1>Bienvenue <?php
                if(isset($_SESSION['prenom']))
                    {
                    echo $_SESSION['prenom'];
                    }
                    ?> à Astrologie Orion</h1>
                <p>C'est avec plaisir que nous vous souhaitons la bienvenue sur le site d'Astrologie Orion.</p> 
                <p>L’astrogie est une science basée sur l'observation des astres que les anciens contemplaient 
                    avec curiosité dans le ciel constellé. Cette myriade de points brillants a tout d'abord donné 
                    aux constellations des formes parfois d'un flou pittoresque, et ce spectacle dont on peut 
                    exprimer la réelle splendeur demeure toujours présent aux quatre coins du monde.</p>
                <p>L'astrologie est la science, des rayons d'énergie et des forces qui conditionnent et régissent
                    le monde. Il s'agit d'en faire bon usage pour en décortiquer le message.</p>
                <p>Découvrez sans tarder les secrets du ciel en notre site, naviguez au fil de nos pages et 
                    émerveillez-vous avec nos article !</p>
            </article>
<?php include 'footer.php';?>