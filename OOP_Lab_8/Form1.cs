using System;

namespace OOP_Lab_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCurrentTime();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void calcFuncBtn_ClickAsync(object sender, EventArgs e)
        {
            textBox1.Clear();
            long result = await CalculateFunctionAsync((int)numericUpDown1.Value);
            textBox1.Text = result.ToString();
        }

        private void startTimerBtn_Click(object sender, EventArgs e)
        {
        }

        private async void sortBtn_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            string result = await BubbleSortAsync((int)numericUpDown2.Value);
            textBox3.Text = result;
        }

        private long CalculateFunction(int size)
        {
            long[] array = new long[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.NextInt64(0, size);
            }
            long sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += array[i];
            }
            return sum / size;
        }

        private async Task<long> CalculateFunctionAsync(int size)
        {
            return await Task.Run(() => CalculateFunction(size));
        }

        private string BubbleSort(int size)
        {
            long[] array = new long[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.NextInt64(0, size);
            }

            int startTime = Environment.TickCount;
            long temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }

            }
            return $"Время сортировки в тиках: {Environment.TickCount - startTime}";
        }

        private async Task<string> BubbleSortAsync(int size)
        {
            return await Task.Run(() => BubbleSort(size));
        }

        private async void GetCurrentTime()
        {
            while (true)
            {
                DateTime date = DateTime.Now;
                systemTimeLabel.Text = date.ToString("HH:mm:ss");
                await Task.Delay(1000 - date.Millisecond);
            }
        }

    }
}