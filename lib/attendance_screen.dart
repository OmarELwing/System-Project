import 'package:flutter/material.dart';

class AttendanceScreen extends StatelessWidget {
  const AttendanceScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Color(0xFF1E4630)),
          onPressed: () => Navigator.maybePop(context),
        ),
        title: const Text('Attendance', style: TextStyle(color: Color(0xFF1E4630), fontWeight: FontWeight.bold)),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16), border: Border.all(color: Colors.grey.shade200)),
              child: const Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text('Overall Attendance', style: TextStyle(color: Colors.grey, fontSize: 13)),
                  SizedBox(height: 4),
                  Text('85%', style: TextStyle(fontSize: 26, fontWeight: FontWeight.bold, color: Color(0xFF1E4630))),
                  SizedBox(height: 8),
                  LinearProgressIndicator(value: 0.85, color: Color(0xFF2E7D32), backgroundColor: Color(0xFFE0E0E0)),
                ],
              ),
            ),
            const SizedBox(height: 12),
            Row(
              children: [
                Expanded(
                  child: Container(
                    padding: const EdgeInsets.all(14),
                    decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16), border: Border.all(color: Colors.grey.shade200)),
                    child: const Row(
                      children: [
                        Icon(Icons.check_circle_outline, color: Colors.green),
                        SizedBox(width: 8),
                        Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text('Present', style: TextStyle(color: Colors.grey, fontSize: 11)),
                            Text('17 Classes', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 13)),
                          ],
                        )
                      ],
                    ),
                  ),
                ),
                const SizedBox(width: 12),
                Expanded(
                  child: Container(
                    padding: const EdgeInsets.all(14),
                    decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16), border: Border.all(color: Colors.grey.shade200)),
                    child: const Row(
                      children: [
                        Icon(Icons.cancel_outlined, color: Colors.red),
                        SizedBox(width: 8),
                        Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text('Absent', style: TextStyle(color: Colors.grey, fontSize: 11)),
                            Text('3 Classes', style: TextStyle(fontWeight: FontWeight.bold, color: Colors.red, fontSize: 13)),
                          ],
                        )
                      ],
                    ),
                  ),
                ),
              ],
            ),
            const SizedBox(height: 20),
            const Text('Attendance History', style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold, color: Color(0xFF1E4630))),
            const SizedBox(height: 12),
            _buildHistoryItem('Sep 07,2026', 'Tuesday', '10:00 AM - 11:30 AM', 'Room 201', true),
            _buildHistoryItem('Sep 05,2026', 'Saturday', '10:00 AM - 11:30 AM', 'Room 201', false),
            _buildHistoryItem('Sep 02,2026', 'Wednesday', '10:00 AM - 11:30 AM', 'Room 201', true),
            _buildHistoryItem('Aug 31,2026', 'Monday', '10:00 AM - 11:30 AM', 'Room 201', true),
          ],
        ),
      ),
    );
  }

  Widget _buildHistoryItem(String date, String day, String time, String room, bool isPresent) {
    return Container(
      margin: const EdgeInsets.only(bottom: 10),
      padding: const EdgeInsets.all(14),
      decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(14), border: Border.all(color: Colors.grey.shade200)),
      child: Row(
        children: [
          Container(
            padding: const EdgeInsets.all(10),
            decoration: BoxDecoration(color: const Color(0xFFE8F5E9), borderRadius: BorderRadius.circular(10)),
            child: const Icon(Icons.menu_book, color: Color(0xFF1E4630), size: 20),
          ),
          const SizedBox(width: 12),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(date, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 13)),
              Text('$day • $time', style: const TextStyle(color: Colors.grey, fontSize: 11)),
              Text(room, style: const TextStyle(color: Colors.grey, fontSize: 11)),
            ],
          ),
          const Spacer(),
          Container(
            padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 4),
            decoration: BoxDecoration(color: isPresent ? const Color(0xFFE8F5E9) : const Color(0xFFFFEBEE), borderRadius: BorderRadius.circular(8)),
            child: Text(
              isPresent ? 'PRESENT' : 'ABSENT',
              style: TextStyle(color: isPresent ? const Color(0xFF2E7D32) : Colors.red, fontSize: 11, fontWeight: FontWeight.bold),
            ),
          )
        ],
      ),
    );
  }
}