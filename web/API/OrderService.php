<?php
session_start();
require_once '../DB/OrderAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "POST")
{
    //Got to send in data.
        createOrder();
}
else if ($method === "GET")
{
        getOrder();
}
function createOrder()
{
    //Check to see if emergency order exists (if type is emergency or order)
    //for the current store


    //
    return "Null";
}

function getOrder()
{
    return "Null";
}

function checkStatus()
{
    return "Null";
}