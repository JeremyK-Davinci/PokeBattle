<?php
    class Attack{
        public $name;
        public $damage;
        public $type;
        public $priority;

        public function __construct($name, $damage, $type, $priority){
            $this->name = $name;
            $this->damage = $damage;
            $this->type = $type;
            $this->priority = $priority;
        }

        public function __toString(){
            return json_encode($this);
        }
    }

    $Attacks = [
        //Normal
        new Attack("Tail Whip", 0, $Types[4], 1),
        new Attack("Growl", 0, $Types[4], 1),
        new Attack("Leer", 0, $Types[4], 1),
        new Attack("Tackle", 40, $Types[4], 1),
        new Attack("Scratch", 40, $Types[4], 1),
        new Attack("Pound", 40, $Types[4], 1),
        new Attack("Quik Attack", 40, $Types[4], 4),

        //Grass
        new Attack("Vine Whip", 40, $Types[2], 1),
        new Attack("Leafage", 40, $Types[2], 1),

        //Fire
        new Attack("Ember", 40, $Types[0], 1),

        //Water
        new Attack("Withdraw", 0, $Types[1], 1),
        new Attack("Water Gun", 40, $Types[1], 1),
        new Attack("Bubble", 40, $Types[1], 1)
    ];