
button.setAttribute("removeFunction")
    function myFunction() {
        var ul = document.getElementById("list");
        var text = document.getElementById("text");
        var li = document.createElement("li");
        //Remove li button
        var button = document.createElement("button")
        button.innerHTML = "Usuń"
        button.onclick = function(){
            var conf = confirm('Czy na pewno chcesz usunąć to zadanie?')
            if (conf == true){
                this.parentNode.parentNode.removeChild(this.parentNode)
            }
            

            
 
        }

        if (text.value.trim() == "") {
            validation.removeAttribute('hidden');
    
        }
        else {
            li.appendChild(button);
            li.setAttribute('id', text.value);
            li.appendChild(document.createTextNode(text.value));
            ul.appendChild(li);
            text.value = "";
            validation.setAttribute('hidden', true);
        }
    }
