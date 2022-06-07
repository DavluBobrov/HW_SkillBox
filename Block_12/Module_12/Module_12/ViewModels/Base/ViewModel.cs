using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Module_12.ViewModels.Base
{
    /// <summary>
    /// INotifyPropertyChanged - интерфейс для отслеживания изменений в свойствах моделей
    /// IDisposable - не обязателен
    /// </summary>
    internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод генерации события привязки к свойству
        /// </summary>
        /// <param name="PropertyName">Имя свойства</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// Обновление значения свойства для которого определено поле для которого он хранит свои данные
        /// Разрешение кольцевых изменений свойств, защита от кольцевого переполнения и выполнения.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Ссылка на поле свойства</param>
        /// <param name="value">Новое значение</param>
        /// <param name="PropertyName">Имя свойства</param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false; // Если поле для обновления уже содержит новое значение, то запрертить это делать
            field = value;                          // Иначе обновляем поле
            OnPropertyChanged(PropertyName);        // Вызов события OnPropertyChanged();
            return true;
        }

        /// <summary> Освобожнение неуправляемых ресурсов </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;

        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _Disposed) return;
            _Disposed = true;
            // Освобождение управляемых ресурсов
        }
    }
}