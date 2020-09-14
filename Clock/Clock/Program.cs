using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            clock clock = new clock();
            subscribEvent sub = new subscribEvent();


            sub.HandleTick(clock);
            while(clock.now<clock.obj)
            {
                System.Threading.Thread.Sleep(1000);
                clock.raiseChanged();
            }
            sub.HandleAlarm(clock);
            clock.raiseAlarm();
        }
    }


    public class clock
    {
        public delegate void AlarmEventHandler(object sender, EventArgs e);

        public event AlarmEventHandler Alarm;
        public event AlarmEventHandler Tick;

        public DateTime now = new DateTime(2020, 9, 14, 12, 01, 50);
        public DateTime obj = new DateTime(2020, 9, 14, 12, 02, 0);


        public virtual void OnTimeChanged(EventArgs e)
        {
            if (this.Tick != null )
            {
                now = now.AddSeconds(1);
                Console.WriteLine(now);
                this.Tick(this, e);
            }
        }
        public void raiseChanged()
        {
            EventArgs e = new EventArgs();
            OnTimeChanged(e);
        }

        

        public void OnAlarm(EventArgs e)
        {
            if(this.Alarm != null)
            {
                Console.WriteLine("下课了");
                this.Alarm(this, e);
            }
        }

        public void raiseAlarm()
        {
            EventArgs e = new EventArgs();
            OnAlarm(e);
        }


    }
    public class subscribEvent
    {
        public void clocktick(object sender,EventArgs e)
        {
            Console.WriteLine("时间过去了一秒...");
        }
        public void HandleTick(clock clock)
        {
            clock.Tick += new clock.AlarmEventHandler(clocktick);
        }

        public void afterAlarm(object sender,EventArgs e)
        {
            Console.WriteLine("响铃...........");
        }

        public void HandleAlarm(clock clock)
        {
            clock.Alarm += new clock.AlarmEventHandler(afterAlarm);
        }

    }
}
