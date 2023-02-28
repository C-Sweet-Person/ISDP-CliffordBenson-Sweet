<?php
session_start();
require_once '../DB/ItemAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "GET")
{
        doGrab();
}




function doGrab(){
    try {
        $body = file_get_contents('php://input');
        $ic = new itemAccessor();
        $items = $ic->getInventoryItems("select * from item");
        //$passReal = password_hash($contents['password'], PASSWORD_DEFAULT);
    //$passwords = [$user->getID(), $user->getUsername(), $user->getPassword(), $user->getEmail(), $bool];
    //$resultsA = json_encode($passwords, JSON_NUMERIC_CHECK);
        $result = json_encode($items,JSON_NUMERIC_CHECK);
} 
catch (PDOException $e) {
        echo $e->getMessage();
    
}
//echo json_encode($ic->getInventoryItems("select * from item"), JSON_NUMERIC_CHECK);
echo json_encode($ic->getInventoryItems("select * from item"), JSON_NUMERIC_CHECK);

}

function doRegister(){
try {
    $body = file_get_contents('php://input');
    $contents = json_decode($body, true);
    $bool = false;
    $ua = new UserAccessor();
    $username = $contents["username"];
    $password = $contents["password"];
    $permission= $contents["permission"];
    $passReal = password_hash($contents['password'], PASSWORD_DEFAULT);
    $userPerson = new User($username,$passReal,$permission);
    $success = $ua->insertUser($userPerson); 
    if ($success){
        echo $success;
        }
    else
       {
        echo $success;
       }
} catch (PDOException $e) {
    $success = true;
    echo $e->getMessage();
}
} 