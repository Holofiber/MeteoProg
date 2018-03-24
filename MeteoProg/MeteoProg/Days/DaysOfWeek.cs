namespace MeteoProg.Days
{
    public class DaysOfWeek
    {
       private readonly Parser _parser = new Parser();

        public DaysOfWeek()
        {
            
        }
       
        public DaysOfWeek(Parser parser)
        {
            _parser = parser;
        }

        public void Days()
        {
            var toDay = _parser.Pars(1);
            var day2 = _parser.Pars(2);
            var day3 = _parser.Pars(3);
            var day4 = _parser.Pars(4);
            var day5 = _parser.Pars(5);
            var day6 = _parser.Pars(6);
            var day7 = _parser.Pars(7);
            var day8 = _parser.Pars(8);
            var day9 = _parser.Pars(9);
            var day10 = _parser.Pars(10);
        }
    }
}
