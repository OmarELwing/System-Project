import 'package:flutter/material.dart';
import 'side_navigation.dart';

class WeeklyScheduleScreen extends StatelessWidget {
  const WeeklyScheduleScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: const AppDrawer(),
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Color(0xFF1E4630)),
          onPressed: () {
            if (Navigator.canPop(context)) {
              Navigator.pop(context);
            } else {
              Scaffold.of(context).openDrawer();
            }
          },
        ),
        title: const Text('Weekly Schedule', style: TextStyle(color: Color(0xFF1E4630), fontWeight: FontWeight.bold)),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: ListView(
        padding: const EdgeInsets.all(16),
        children: [
          const Text('Sunday, September 21', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Color(0xFF1E4630))),
          const SizedBox(height: 12),
          _buildItem('10:00 AM', 'Database Systems', 'CS301', 'Dr.Ahmed Al-Abbasi', 'Room 302'),
          _buildItem('12:00 PM', 'Data Mining', 'CS302', 'Dr.Sara Mohamed', 'Room 201'),
          _buildItem('02:00 PM', 'Computer Vision', 'CS303', 'Dr.Ali Mahmoud', 'Room 101'),
        ],
      ),
    );
  }

  Widget _buildItem(String time, String title, String code, String doctor, String room) {
    return Container(
      margin: const EdgeInsets.only(bottom: 12),
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16)),
      child: Row(
        children: [
          Text(time, style: const TextStyle(fontWeight: FontWeight.bold)),
          const SizedBox(width: 16),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(title, style: const TextStyle(fontWeight: FontWeight.bold)),
                Text('$code • $doctor • $room', style: const TextStyle(color: Colors.grey, fontSize: 11)),
              ],
            ),
          )
        ],
      ),
    );
  }
}