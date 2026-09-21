import 'package:flutter/material.dart';

class AssessmentScreen extends StatelessWidget {
  const AssessmentScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Color(0xFF1E4630)),
          onPressed: () => Navigator.maybePop(context),
        ),
        title: const Text('Assessment', style: TextStyle(color: Color(0xFF1E4630), fontWeight: FontWeight.bold)),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16), border: Border.all(color: Colors.grey.shade200)),
              child: const Row(
                children: [
                  CircleAvatar(backgroundColor: Color(0xFFE8F5E9), child: Icon(Icons.storage, color: Color(0xFF1E4630))),
                  SizedBox(width: 12),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text('Database Systems', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15)),
                      Text('CS301', style: TextStyle(color: Colors.grey, fontSize: 12)),
                    ],
                  ),
                  Spacer(),
                  Icon(Icons.arrow_forward_ios, size: 14, color: Colors.grey),
                ],
              ),
            ),
            const SizedBox(height: 12),
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16), border: Border.all(color: Colors.grey.shade200)),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  _buildStat('Total Assessments', '6'),
                  _buildStat('Completed', '6'),
                  _buildStat('Average Score', '16.5 / 20'),
                ],
              ),
            ),
            const SizedBox(height: 20),
            const Align(
              alignment: Alignment.centerLeft,
              child: Text('Assessments', style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold, color: Color(0xFF1E4630))),
            ),
            const SizedBox(height: 12),
            _buildItem('Quiz 1', 'Quiz', 'Sep 03, 2026', '18/20'),
            _buildItem('Assignment 1', 'Assignment', 'Aug 28, 2026', '9/10'),
            _buildItem('Quiz 2', 'Quiz', 'Aug 20, 2026', '16/20'),
            _buildItem('Assignment 2', 'Assignment', 'Aug 12, 2026', '6/10'),
          ],
        ),
      ),
    );
  }

  Widget _buildStat(String title, String val) {
    return Column(
      children: [
        Text(title, style: const TextStyle(color: Colors.grey, fontSize: 11)),
        const SizedBox(height: 4),
        Text(val, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 14)),
      ],
    );
  }

  Widget _buildItem(String title, String type, String date, String score) {
    return Container(
      margin: const EdgeInsets.only(bottom: 10),
      padding: const EdgeInsets.all(14),
      decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(14), border: Border.all(color: Colors.grey.shade200)),
      child: Row(
        children: [
          Container(
            padding: const EdgeInsets.all(10),
            decoration: BoxDecoration(color: const Color(0xFFE8F5E9), borderRadius: BorderRadius.circular(10)),
            child: const Icon(Icons.assignment_outlined, color: Color(0xFF1E4630)),
          ),
          const SizedBox(width: 12),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(title, style: const TextStyle(fontWeight: FontWeight.bold)),
              Text(type, style: const TextStyle(color: Colors.grey, fontSize: 11)),
              Text(date, style: const TextStyle(color: Colors.grey, fontSize: 10)),
            ],
          ),
          const Spacer(),
          Column(
            crossAxisAlignment: CrossAxisAlignment.end,
            children: [
              Text(score, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 15)),
              const SizedBox(height: 4),
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 2),
                decoration: BoxDecoration(color: const Color(0xFFE8F5E9), borderRadius: BorderRadius.circular(6)),
                child: const Text('Graded', style: TextStyle(color: Color(0xFF2E7D32), fontSize: 10, fontWeight: FontWeight.bold)),
              ),
            ],
          )
        ],
      ),
    );
  }
}