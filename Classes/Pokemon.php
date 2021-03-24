<?php 
    class Pokemon{
        protected static $Pokemons = [];

        public $name;
        public $type;
        public $hitPoints;
        public $maxHitPoints;
        public $baseHitPoints;
        public $level;
        public $attacks;

        public $fainted = false;

        public function __construct($name, $type, $baseHitPoints, $level, $attacks){
            $this->name = $name;
            $this->type = $type;
            $this->baseHitPoints = $baseHitPoints;
            $this->level = $level;
            $this->hitPoints = $this->calculateHitPoints();
            $this->maxHitPoints = $this->hitPoints;
            $this->attacks = $attacks;
            self::$Pokemons[] = $this;
        }

        public static function __constructWithHP($name, $type, $baseHitPoints, $level, $hitPoints, $attacks){
            $this->name = $name;
            $this->type = $type;
            $this->baseHitPoints = $baseHitPoints;
            $this->level = $level;
            $this->hitPoints = $hitPoints;
            $this->maxHitPoints = $this->hitPoints;
            $this->attacks = $attacks;
            self::$Pokemons[] = $this;
        }

        public function __toString(){
            return json_encode($this);
        }

        public function __getTypeFromMyId(){
            return $Types[$this->type];
        }

        //This function and it's child (__getPopulationHealth) won't work right now no matter how much I want it to due to the way sp code is setup...
        public function __getPopulation(){
            $return = [];
            foreach(self::$Pokemons as $Pokemon){
                if($Pokemon instanceof $this){
                    if($Pokemon->hitPoints > 0){
                        $return[] = $Pokemon;
                    }
                }
            }
            return $return;
        }

        public function __getPopulationHealth(){
            $return = [];
            foreach(self::$Pokemons as $Pokemon){
                if($Pokemon instanceof $this){
                    if($Pokemon->hitPoints > 0){
                        $return[] = $Pokemon->hitPoints;
                    }
                }
            }
            return $return;
        }

        public function __calculateNewHitPoints(){
            $increment = rand(1, 3);
            $this->hitPoints += $increment;
            $this->maxHitPoints = $this->hitPoints;
        }

        function calculateHitPoints(){
            $return = $this->baseHitPoints;
            for($i = 1; $i < $this->level; $i++){
                $increment = rand(1, 3);
                $return += $increment;
            }
            return $return;
        }
    }

    $BasePokemon = [ //Remember to manually json_encode when calling a pokemon
        //Generation 1
        //Bulbasaur
        new Pokemon("Bulbasaur", $Types[2], 45, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Vine Whip', $Attacks)]),

        //Charmander
        new Pokemon("Charmander", $Types[0], 39, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Scratch', $Attacks), getArrayObjectByName('Ember', $Attacks)]),

        //Squirtle
        new Pokemon("Squirtle", $Types[1], 44, 5, [getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Tail Whip', $Attacks), getArrayObjectByName('Water Gun', $Attacks)]),


        //Generation 2
        //Chikorita
        new Pokemon("Chikorita", $Types[2], 45, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Tackle', $Attacks)]),

        //Cyndaquil
        new Pokemon("Cyndaquil", $Types[0], 39, 5, [getArrayObjectByName('Leer', $Attacks), getArrayObjectByName('Tackle', $Attacks)]),

        //Totodile
        new Pokemon("Totodile", $Types[1], 50, 5, [getArrayObjectByName('Leer', $Attacks), getArrayObjectByName('Scratch', $Attacks)]),


        //Generation 3
        //Treecko
        new Pokemon("Treecko", $Types[2], 40, 5, [getArrayObjectByName('Leer', $Attacks), getArrayObjectByName('Pound', $Attacks), getArrayObjectByName('Leafage', $Attacks)]),

        //Torchic
        new Pokemon("Torchic", $Types[0], 45, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Scratch', $Attacks), getArrayObjectByName('Ember', $Attacks)]),

        //Mudkip
        new Pokemon("Mudkip", $Types[1], 50, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Water Gun', $Attacks)]),


        //Generation 4
        //Turtwig
        new Pokemon("Turtwig", $Types[2], 55, 5, [getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Withdraw', $Attacks)]),

        //Chimchar
        new Pokemon("Chimchar", $Types[0], 44, 5, [getArrayObjectByName('Leer', $Attacks), getArrayObjectByName('Scratch', $Attacks)]),

        //Piplup
        new Pokemon("Piplup", $Types[1], 53, 5, [getArrayObjectByName('Pound', $Attacks), getArrayObjectByName('Growl', $Attacks)]),


        //Generation 5
        //Snivy
        new Pokemon("Snivy", $Types[2], 45, 5, [getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Leer', $Attacks)]),

        //Tepig
        new Pokemon("Tepig", $Types[0], 65, 5, [getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Tail Whip', $Attacks)]),

        //Oshawott
        new Pokemon("Oshawott", $Types[1], 55, 5, [getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Tail Whip', $Attacks)]),


        //Generation 6
        //Chespin
        new Pokemon("Chespin", $Types[2], 56, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Vine Whip', $Attacks)]),

        //Fennekin
        new Pokemon("Fennekin", $Types[0], 40, 5, [getArrayObjectByName('Scratch', $Attacks), getArrayObjectByName('Tail Whip', $Attacks), getArrayObjectByName('Ember', $Attacks)]),

        //Froakie
        new Pokemon("Froakie", $Types[1], 41, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Pound', $Attacks), getArrayObjectByName('Bubble', $Attacks)]),


        //Generation 7
        //Rowlet
        new Pokemon("Rowlet", $Types[2], 68, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Leafage', $Attacks)]),

        //Litten
        new Pokemon("Litten", $Types[0], 45, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Tackle', $Attacks), getArrayObjectByName('Ember', $Attacks)]),

        //Popplio
        new Pokemon("Popplio", $Types[1], 50, 5, [getArrayObjectByName('Growl', $Attacks), getArrayObjectByName('Pound', $Attacks), getArrayObjectByName('Water Gun', $Attacks)])
    ];