function myFunction() {
    var ul = document.getElementById("list");
    var text = document.getElementById("text");
    var li = document.createElement("li");
    
    if (document.getElementById("text").value == '') {
        document.getElementById('QQQ').removeAttribute('hidden');

    } else {
        li.setAttribute('id', text.value);
        li.appendChild(document.createTextNode(text.value));
        ul.appendChild(li);
        document.getElementById('text').value = "";

        document.getElementById('QQQ').setAttribute('hidden', true);
    }

}
