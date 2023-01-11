<?php
session_start();
require_once '../DB/UserAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "POST")
{
        doLogin();
}




function doLogin(){
    try {
        $body = file_get_contents('php://input');
        $contents = json_decode($body, true);
        $bool = false;
        $username = $contents["username"];
        $password = $contents["password"];
        $uc = new UserAccessor();
        $user = $uc->getUserByUsername($username);
        //$passReal = password_hash($contents['password'], PASSWORD_DEFAULT);
    if (password_verify($password, $user[0]->getPassword()) === true) {
        $bool = true;
    } else {
        $bool = false;
    }
    $passwords = [$user[0]->getID, $user[0]->getUsername, $user[0]->getPassword(), $user[0]->getEmail(), $bool];
    $resultsA = json_encode($passwords, JSON_NUMERIC_CHECK);
    $success = true;
    $_SESSION["username"] = json_encode($user[0], JSON_NUMERIC_CHECK);
} 
catch (PDOException $e) {
    echo $e->getMessage();
}
echo $resultsA;
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