﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {   
        private readonly Players _players;

        private readonly Questions _questions;
        
        bool isGettingOutOfPenaltyBox;
        private readonly IDispatchEvent _eventDispatcher;


        public Game(Players players, Questions questions, IDispatchEvent eventDispatcher)
        {
            _players = players;
            _questions = questions;
            _eventDispatcher = eventDispatcher;
        }

        public void Roll(int roll)
        {
            _eventDispatcher.Dispatch(new PlayerRolledDice(_players.Current.Name, roll));
            _eventDispatcher.Display(_players.Current.Name + " is the current player");
            _eventDispatcher.Display("They have rolled a " + roll);

            if (_players.Current.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    _eventDispatcher.Display(_players.Current.Name + " is getting out of the penalty box");
                    _players.Current.Move(roll);

                    _eventDispatcher.Display(_players.Current.Name
                            + "'s new location is "
                            + _players.Current.Place);
                    _questions.AskQuestion(_players.Current.Place);
                }
                else
                {
                    _eventDispatcher.Display(_players.Current.Name + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players.Current.Move(roll);

                _eventDispatcher.Display(_players.Current.Name
                        + "'s new location is "
                        + _players.Current.Place);
                _questions.AskQuestion(_players.Current.Place);
            }

        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players.Current.InPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    _eventDispatcher.Display("Answer was correct!!!!");
                    _players.Current.WinAGoldCoin();

                    winner = _players.Current.IsWinner();
                    _players.NextPlayer();

                    return winner;
                }

                _players.NextPlayer();
                return false;
            }

            _eventDispatcher.Display("Answer was corrent!!!!");
            _players.Current.WinAGoldCoin();

            winner = _players.Current.IsWinner();
            _players.NextPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            _eventDispatcher.Display("Question was incorrectly answered");
            _eventDispatcher.Display(_players.Current.Name + " was sent to the penalty box");
            _players.Current.GoToPenaltyBox();

            _players.NextPlayer();
            return false;
        }
    }
}
