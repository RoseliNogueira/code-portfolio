function confirmation()
{    
   if(document.getElementById("myEmail").value !="" && document.getElementById("txtNom").value != "")
   {
       alert("Merci " + document.getElementById("txtNom").value + " ,nous avons bien reçu votre courriel. Vous recevrez un courriel de confirmation bientôt à l'adresse suivante: " +document.getElementById("myEmail").value + ".");
   }
      
   
}