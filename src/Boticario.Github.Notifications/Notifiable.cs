using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Notifications
{
    public abstract class Notifiable
    {
        public Note Notes { get; private set; } = new Note();

        /// <summary>
        /// Testa se a condição é verdadeira, caso o teste falhe, adiciona um nota contendo a description informada
        /// </summary>
        /// <param name="condition">condição a ser testada</param>
        /// <param name="description">Descrição para a falha do teste avaliado</param>
        public void Test(bool condition, Description description)
        {
            if (condition)
                Notes.Add(description);
        }

        public bool IsValid()
        {
            return !Notes.HasErrors;
        }

        public abstract void Validate();
    }
}
