<!DOCTYPE html>

<html>
    <head>
        <title>Mon site</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="OrionStyle.css" />
        <!--[if It IE 9]>
        <script src="http://html5shiv.googlecode.com/svn/trumk/html5.js">
        </script>
        <![endif]-->
    </head>
    <body id="Accueil">        
        <div id="Principal">
            <header>
                <?php
                include 'Fonctions.php';
                TeteDePage();
                AfficherMenu();
                ?>
            </header>