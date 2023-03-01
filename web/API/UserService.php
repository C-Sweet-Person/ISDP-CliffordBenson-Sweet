<?php
session_start();
require_once '../DB/UserAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];

if ($method === "POST")
{
        doLogin();
}



function doLogin(){
    $bool = 0;
    try {
        $body = file_get_contents('php://input');
        $contents = json_decode($body, true);
        $username = $contents["username"];
        $password = $contents["password"];
        $uc = new UserAccessor();
        $user = $uc->getUserByUsername($username);
        //$passReal = password_hash($contents['password'], PASSWORD_DEFAULT);
    if (strcmp($password,$user[0]->getPassword()) === 0) {
        $bool = 1;
    } else {
        $bool = 0;
    }
    //$passwords = [$user->getID(), $user->getUsername(), $user->getPassword(), $user->getEmail(), $bool];
    //$resultsA = json_encode($passwords, JSON_NUMERIC_CHECK);
    $success = true;
    $_SESSION["user"] = json_encode($user, JSON_NUMERIC_CHECK);

} 
catch (PDOException $e) {
    echo $e->getMessage() . "Help" . print_r($user);
    
}
echo $bool;
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