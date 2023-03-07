<html>
<head>
<title>Web Order - Bullsye Sporting Goods</title>
<meta charset="UTF-8">
<style>
    .hidden
    {
        display:none;
        color:red;
    }
    </style>
</head>
<body>
<h1>Items to order.</h1>
<label for="storeSelect">Store Select: </label><select name="Store" id="storeSelect"></select>
<label for="itemSearch">Search items: </label><input type ="text" id="itemSearch"><button id="searchButton">Search</button>
<table id="tableItems"></table>
<script src="scripts/webOrdering.js"></script>
</body>
</html>