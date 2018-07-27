using System.Collections.Generic;
using System.Linq;

using Android.Content;
using Android.Views;
using Android.Widget;

namespace SimpleMapDemo
{
    class SimpleMapDemoActivityAdapter : BaseAdapter<SampleActivity>
    {
        readonly List<SampleActivity> _activities;
        readonly Context _context;

        public SimpleMapDemoActivityAdapter(Context context, IEnumerable<SampleActivity> sampleActivities)
        {
            _context = context;
            if (sampleActivities == null)
            {
                _activities = new List<SampleActivity>(0);
            }
            else
            {
                _activities = sampleActivities.ToList();
            }
        }

        public override int Count => _activities.Count;

        public override SampleActivity this[int position] => _activities[position];

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView as FeatureRowHolder ?? new FeatureRowHolder(_context);
            var sample = _activities[position];

            row.UpdateFrom(sample);
            return row;
        }
    }
}
