function myFunction() {
    var ul = document.getElementById("list");
    var text = document.getElementById("text");
    var li = document.createElement("li");
    
    if (text.value.trim() == "") {
        validation.removeAttribute('hidden');

    }
    else {
        li.setAttribute('id', text.value);
        li.appendChild(document.createTextNode(text.value));
        ul.appendChild(li);
        text.value = "";
        validation.setAttribute('hidden', true);
    }

}