﻿using System;
using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Flows.Events;
using BotCreators.BotModule.Flows.Inputs;
using BotCreators.BotModule.Flows.Responses;

namespace BotCreators.DataSource
{

    /*
     * На данный момент здесь будут создавать тестовые потоки сообщений.
     * В дальнешйенм данный класс будет отвечать за загрузку потоков из базы данных или другого формата хранения.
     */

    public class FlowSource
    {
        private static readonly List<Flow> Flows = new List<Flow>();

        static FlowSource()
        {
            Flows.Add(
                item: CreateFlowHowAreYou()
                );
        }
        
        public static Flow GetFlowById(string id)
        {
            return Flows.FirstOrDefault(p => p.Id.Equals(id));
        }

        private static Flow CreateFlowHowAreYou()
        {
            var flow = new Flow("how_are_you");

            var howAreYou = new Chain()
            {
                Id = "how_are_you",
                StartEvent = new NewMessageEvent
                {
                    Input = new SimpleInput("Как дела?")
                },
                Responses = new List<IResponse>
                {
                    new SimpleResponse("Отлично")
                }
            };

            (howAreYou.StartEvent as NewMessageEvent).IsDisplay = true;

            flow.Head = new FlowNode(howAreYou);

            return flow;
        }


        

        /*
         * Отправляет пользователю акцию в заданное время.
         */
        private static Flow CreateFlowDeliveryNewActionByTime()
        {
            throw new System.NotImplementedException();
        }

        /*
         * Добавляет акцию 
         */
        private static Flow CreateFlowAddAction()
        {
            throw new System.NotImplementedException();
        }

        /*
         * Помогает получить права администратора
         */
        private static Flow CreateFlowGetAdminRight()
        {
            throw new System.NotImplementedException();
        }

        /*
         * Отправляет акции пользователю после добавления
         */
        private static Flow CreateFlowDeliveryNewActionByAdd()
        {
            throw new System.NotImplementedException();
        }

        /*
         * Позволяет пользователю подписаться на акции
         */
        private static Flow CreateFlowSubscribeAction()
        {
            throw new System.NotImplementedException();
        }

        /*
         * Позволяет пользователю получить текущие акции
         */
        private static Flow CreateFlowGetAction()
        {
            var result = new Flow
            {
                /*BotId = "flow_get_action",
                InnerChains = new List<Chain>
                {
                    new Chain
                    {
                        StartEvent = new NewMessageEvent
                        {
                            SimpleInput = new SimpleInput("Расскажи мне о акциях"),
                            GeneralStartInput = "Расскажи мне о акциях"
                        },
                        Action = new List<Action>(),
                        Responses = new List<IResponse>
                        {
                            new IResponse("actions")
                        }
                    }
                }*/
            };

            return result;
        }

        /*
         * Позволяет пользователю получить консультацию у реального человека
         */
        private static Flow CreateFlowGetConsultation()
        {
            throw new System.NotImplementedException();
        }

        /*
         * Рассказывает пользователю о том, что такое чат-боты и зачем они нужны
         */
        private static Flow CreateFlowAboutBot()
        {
            var result = new Flow
            {
                /*BotId = "flow_about_bot",
                InnerChains = new List<Chain>
                {
                    new Chain
                    {
                        StartEvent = new NewMessageEvent
                        {
                            SimpleInput = new SimpleInput("Расскажи мне о ботах"),
                            GeneralStartInput = "Расскажи мне о ботах"
                        },
                        Action = new List<Action>(),
                        Responses = new List<IResponse>
                        {
                            new IResponse("Они классные")
                        }
                    }
                }*/
            };


            return result;
        }
    }
}
