<?php session_start();
if(isset($_SESSION['prenom']))
{
    echo $_SESSION['prenom'];
}

include 'header.php'; ?>
            <section id="Contenu">
                <article>
                    <h1>Astrologie</h1>
                    <p>L'astrologue classe les signes de différentes façons : </p>
                    <p><em><a href="Mode_Vibratoires.php">Les modes vibratoires</a> : </em> signes cardinaux en début de saison 
                        (Bélier, Cancer, Balance et Capricorne), signes fixes en milieu de
                        saison (Taureau, Lion, Scorpion et Verseau) et signes mutables 
                        en fin de saison (Gémeaux, Vierge, Sagittaire et Poissons). </p>
                    <p><em><a href="Elements.php">Les éléments </a> : </em>signes de feu (Bélier, Lion et Sagittaire),
                        signes de terre (Taureau, Vierge et Capricorne), signes d'air 
                        (Gémeaux, Balance et Verseau) et signes d'eau (Cancer, Scorpion et Poissons).</p>
                    <p>Chaque signe est aussi découpé en 3 décans de 10°, ce qui affine
                        le portrait de naissance et apporte plus de précisions aux prévisions.</p>
                    <p>Découvrez sans tarder les secrets du ciel en notre site, naviguez
                        au fil de nos pages et émerveillez-vous avec le contenue !</p>
                    <p>Bonne lecture !</p>
                </article>
<?php include 'footer.php'; ?>