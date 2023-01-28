<html>
    <head>
        <style>
            #tableItems th, td, table 
            {
                border: solid thin black;
                border-collapse: collapse;
                padding: 2px;
            }
            #tableDisplay
            {
                border: solid thin black;
                padding: 5px;
                height: 300px;
                overflow: scroll;
                width: fit-content;
                margin: auto;
            }
        </style>
</head>
<body>
<h1>User Dashboard</h1>
<hr>
<div id="tableDisplay"><table id="tableItems"></table>
</div>
<table>
</table>
<p id="currentIndex"></p>
<button id="Previous">Prev</button>
<button id="Forward">Next</button>
<script src="Dashboard.js"></script>

</body>
</html>