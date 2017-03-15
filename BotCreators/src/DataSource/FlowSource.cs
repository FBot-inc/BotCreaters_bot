using System;
using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;

namespace BotCreators.DataSource
{
    public class FlowSource
    {
        public static List<Flow> Flows = CreateFlows();

        private static List<Flow> CreateFlows()
        {
            var result = new List<Flow>
            {
                CreateFlowAboutBot(),
                //CreateFlowGetConsultation(),
                CreateFlowGetAction(),
                //CreateFlowSubscribeAction(),
                //CreateFlowDeliveryNewActionByAdd(),
                //CreateFlowDeliveryNewActionByTime(),
                //CreateFlowGetAdminRight(),
                //CreateFlowAddAction()
            };


            return result;
        }


        //todo возможно необходимо будет каждый раз создавать разные
        public static Flow GetFlowById(string id)
        {
            return Flows.FirstOrDefault(p => p.Id.Equals(id));
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
                Id = "flow_get_action",
                InnerChains = new List<InnerChain>
                {
                    new InnerChain
                    {
                        StartEvent = new NewMessageEvent
                        {
                            Input = new Input("Расскажи мне о акциях"),
                            GeneralStartInput = "Расскажи мне о акциях"
                        },
                        Action = new List<Action>(),
                        Responses = new List<Response>
                        {
                            new Response("actions")
                        }
                    }
                }
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
                Id = "flow_about_bot",
                InnerChains = new List<InnerChain>
                {
                    new InnerChain
                    {
                        StartEvent = new NewMessageEvent
                        {
                            Input = new Input("Расскажи мне о ботах"),
                            GeneralStartInput = "Расскажи мне о ботах"
                        },
                        Action = new List<Action>(),
                        Responses = new List<Response>
                        {
                            new Response("Они классные")
                        }
                    }
                }
            };


            return result;
        }
    }
}
