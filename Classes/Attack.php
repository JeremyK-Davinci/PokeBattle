<?php
    class Attack{
        public $name;
        public $damage;
        public $type;

        public function __construct($name, $damage, $type){
            $this->name = $name;
            $this->damage = $damage;
            $this->type = $type;
        }

        public function __toString(){
            return json_encode($this);
        }
    }