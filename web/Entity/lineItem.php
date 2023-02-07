<?php

class lineItem implements JsonSerializable
{
    private $txnID;
    private $itemID;
    private $quantity;

    public function __construct($txnID, $itemID, $quantity)
    {
        $this->txnID = $txnID;
        $this->itemID = $itemID;
        $this->$quantity = $quantity;
    }

    public function getTxnID()
    {
        return $this->txnID;
    }

    public function getItemID()
    {
        return $this->itemID;
    }

    public function getQuantity()
    {
        return $this->quantity;
    }
    public function jsonSerialize()
    {
        return get_object_vars($this);
    }
}
